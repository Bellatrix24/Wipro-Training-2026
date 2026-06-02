//checks if contact is valid
function validateContact(contact) {
  const errors = [];
  
  if (!contact.name || contact.name.trim() === '') {
    errors.push('Name is required');
  }
  
  if (!contact.email || contact.email.trim() === '') {
    errors.push('Email is required');
  } else {
    //simple email format check
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (!emailRegex.test(contact.email)) {
      errors.push('Invalid email format');
    }
  }
  
  return {
    isValid: errors.length === 0,
    errors
  };
}

//exports validation function
module.exports = {
  validateContact
};
