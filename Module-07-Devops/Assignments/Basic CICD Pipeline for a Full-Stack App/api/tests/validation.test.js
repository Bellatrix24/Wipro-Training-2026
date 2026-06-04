const { validateContact } = require('../utils/validation');

describe('Validation Unit Tests', () => {
  //tests valid contact data
  test('should pass with valid name and email', () => {
    const contact = {
      name: 'John Doe',
      email: 'john@example.com'
    };
    const result = validateContact(contact);
    expect(result.isValid).toBe(true);
    expect(result.errors.length).toBe(0);
  });

  //tests missing name
  test('should fail when name is missing', () => {
    const contact = {
      name: '',
      email: 'john@example.com'
    };
    const result = validateContact(contact);
    expect(result.isValid).toBe(false);
    expect(result.errors).toContain('Name is required');
  });

  //tests missing email
  test('should fail when email is missing', () => {
    const contact = {
      name: 'John Doe',
      email: ' '
    };
    const result = validateContact(contact);
    expect(result.isValid).toBe(false);
    expect(result.errors).toContain('Email is required');
  });

  //tests invalid email format
  test('should fail when email format is invalid', () => {
    const contact = {
      name: 'John Doe',
      email: 'invalid-email'
    };
    const result = validateContact(contact);
    expect(result.isValid).toBe(false);
    expect(result.errors).toContain('Invalid email format');
  });
});
