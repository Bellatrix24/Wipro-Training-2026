const request = require('supertest');
const mongoose = require('mongoose');
const { MongoMemoryServer } = require('mongodb-memory-server');
const app = require('../app');
const Contact = require('../models/Contact');

let mongoServer;

//starts database server before tests run
beforeAll(async () => {
  let uri;
  if (process.env.MONGO_URI_TEST) {
    //uses the service container provided in environment
    uri = process.env.MONGO_URI_TEST;
  } else {
    //falls back to local memory server
    mongoServer = await MongoMemoryServer.create();
    uri = mongoServer.getUri();
  }
  await mongoose.connect(uri);
});

//stops database server after all tests are done
afterAll(async () => {
  await mongoose.disconnect();
  if (mongoServer) {
    await mongoServer.stop();
  }
});

//clears contacts collection after each individual test
afterEach(async () => {
  await Contact.deleteMany({});
});

describe('Integration Tests', () => {
  //tests health check route
  test('GET /api/health should return ok status', async () => {
    const res = await request(app).get('/api/health');
    expect(res.status).toBe(200);
    expect(res.body.status).toBe('ok');
    expect(res.body.message).toBe('server is healthy');
  });

  //tests successful creation of contact
  test('POST /api/contacts should create a new contact', async () => {
    const contactData = {
      name: 'Alice Smith',
      email: 'alice@example.com',
      phone: '1234567890',
      company: 'TechCorp',
      notes: 'New client'
    };

    const res = await request(app)
      .post('/api/contacts')
      .send(contactData);

    expect(res.status).toBe(201);
    expect(res.body._id).toBeDefined();
    expect(res.body.name).toBe('Alice Smith');
    expect(res.body.email).toBe('alice@example.com');

    //verifies item was saved in the db
    const savedContact = await Contact.findById(res.body._id);
    expect(savedContact).not.toBeNull();
    expect(savedContact.name).toBe('Alice Smith');
  });

  //tests creation failing validation checks
  test('POST /api/contacts should fail with empty data', async () => {
    const res = await request(app)
      .post('/api/contacts')
      .send({ name: '', email: '' });

    expect(res.status).toBe(400);
    expect(res.body.errors).toBeDefined();
    expect(res.body.errors).toContain('Name is required');
    expect(res.body.errors).toContain('Email is required');
  });
});
