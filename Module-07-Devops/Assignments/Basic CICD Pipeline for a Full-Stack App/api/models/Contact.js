const mongoose = require('mongoose');

//defines contact fields
const contactSchema = new mongoose.Schema({
  name: {
    type: String,
    required: true
  },
  email: {
    type: String,
    required: true
  },
  phone: {
    type: String
  },
  company: {
    type: String
  },
  notes: {
    type: String
  }
}, {
  timestamps: true
});

//exports contact model
module.exports = mongoose.model('Contact', contactSchema);
