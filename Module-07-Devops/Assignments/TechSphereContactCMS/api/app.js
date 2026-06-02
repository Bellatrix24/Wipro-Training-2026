const express = require('express');
const cors = require('cors');
const Contact = require('./models/Contact');
const { validateContact } = require('./utils/validation');

const app = express();

//enables cross-origin resource sharing
app.use(cors());
//parses incoming json requests
app.use(express.json());

//health check endpoint
app.get('/api/health', (req, res) => {
  res.status(200).json({ status: 'ok', message: 'server is healthy' });
});

//get all contacts
app.get('/api/contacts', async (req, res) => {
  try {
    const contacts = await Contact.find();
    res.status(200).json(contacts);
  } catch (error) {
    res.status(500).json({ error: error.message });
  }
});

//get a single contact by id
app.get('/api/contacts/:id', async (req, res) => {
  try {
    const contact = await Contact.findById(req.params.id);
    if (!contact) {
      return res.status(404).json({ message: 'Contact not found' });
    }
    res.status(200).json(contact);
  } catch (error) {
    res.status(500).json({ error: error.message });
  }
});

//create a new contact
app.post('/api/contacts', async (req, res) => {
  try {
    const { name, email, phone, company, notes } = req.body;
    
    //validates contact data
    const validation = validateContact({ name, email });
    if (!validation.isValid) {
      return res.status(400).json({ errors: validation.errors });
    }

    const newContact = new Contact({ name, email, phone, company, notes });
    await newContact.save();
    res.status(201).json(newContact);
  } catch (error) {
    res.status(500).json({ error: error.message });
  }
});

//update an existing contact
app.put('/api/contacts/:id', async (req, res) => {
  try {
    const { name, email, phone, company, notes } = req.body;
    
    //validates contact data
    const validation = validateContact({ name, email });
    if (!validation.isValid) {
      return res.status(400).json({ errors: validation.errors });
    }

    const contact = await Contact.findById(req.params.id);
    if (!contact) {
      return res.status(404).json({ message: 'Contact not found' });
    }

    contact.name = name;
    contact.email = email;
    contact.phone = phone;
    contact.company = company;
    contact.notes = notes;

    await contact.save();
    res.status(200).json(contact);
  } catch (error) {
    res.status(500).json({ error: error.message });
  }
});

//delete a contact
app.delete('/api/contacts/:id', async (req, res) => {
  try {
    const contact = await Contact.findByIdAndDelete(req.params.id);
    if (!contact) {
      return res.status(404).json({ message: 'Contact not found' });
    }
    res.status(200).json({ message: 'Contact deleted successfully' });
  } catch (error) {
    res.status(500).json({ error: error.message });
  }
});

//exports the express application
module.exports = app;
