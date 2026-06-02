import React, { useState, useEffect } from 'react';

//gets the backend api url
const API_BASE_URL = import.meta.env.VITE_API_BASE_URL || 'http://localhost:5000';

function App() {
  const [contacts, setContacts] = useState([]);
  const [name, setName] = useState('');
  const [email, setEmail] = useState('');
  const [phone, setPhone] = useState('');
  const [company, setCompany] = useState('');
  const [notes, setNotes] = useState('');
  const [editingId, setEditingId] = useState(null);
  const [error, setError] = useState('');
  const [success, setSuccess] = useState('');

  //runs when the component mounts
  useEffect(() => {
    fetchContacts();
  }, []);

  //fetches all contacts from the server
  const fetchContacts = async () => {
    try {
      const response = await fetch(`${API_BASE_URL}/api/contacts`);
      if (response.ok) {
        const data = await response.json();
        setContacts(data);
      } else {
        setError('Failed to fetch contacts');
      }
    } catch (err) {
      setError('Failed to connect to the backend server');
    }
  };

  //resets form fields to empty values
  const resetForm = () => {
    setName('');
    setEmail('');
    setPhone('');
    setCompany('');
    setNotes('');
    setEditingId(null);
    setError('');
  };

  //saves a new contact or updates an existing one
  const handleSubmit = async (e) => {
    e.preventDefault();
    setError('');
    setSuccess('');

    //simple client side validation
    if (!name.trim() || !email.trim()) {
      setError('Name and Email are required');
      return;
    }

    const contactData = { name, email, phone, company, notes };

    try {
      let response;
      if (editingId) {
        //updates an existing contact
        response = await fetch(`${API_BASE_URL}/api/contacts/${editingId}`, {
          method: 'PUT',
          headers: { 'Content-Type': 'application/json' },
          body: JSON.stringify(contactData),
        });
      } else {
        //creates a new contact
        response = await fetch(`${API_BASE_URL}/api/contacts`, {
          method: 'POST',
          headers: { 'Content-Type': 'application/json' },
          body: JSON.stringify(contactData),
        });
      }

      const result = await response.json();

      if (response.ok) {
        setSuccess(editingId ? 'Contact updated successfully' : 'Contact created successfully');
        resetForm();
        fetchContacts();
      } else {
        if (result.errors) {
          setError(result.errors.join(', '));
        } else {
          setError(result.message || 'Something went wrong');
        }
      }
    } catch (err) {
      setError('Failed to save contact');
    }
  };

  //sets up form fields for editing
  const handleEdit = (contact) => {
    setEditingId(contact._id);
    setName(contact.name);
    setEmail(contact.email);
    setPhone(contact.phone || '');
    setCompany(contact.company || '');
    setNotes(contact.notes || '');
    setError('');
    setSuccess('');
  };

  //deletes a contact from the database
  const handleDelete = async (id) => {
    if (!window.confirm('Are you sure you want to delete this contact?')) {
      return;
    }

    try {
      const response = await fetch(`${API_BASE_URL}/api/contacts/${id}`, {
        method: 'DELETE',
      });

      if (response.ok) {
        setSuccess('Contact deleted successfully');
        fetchContacts();
        if (editingId === id) {
          resetForm();
        }
      } else {
        setError('Failed to delete contact');
      }
    } catch (err) {
      setError('Failed to delete contact');
    }
  };

  return (
    <div className="app-container">
      <header className="app-header">
        <h1>TechSphere Contact CMS</h1>
        <p className="app-subtitle">Simple Student Contact Management System</p>
      </header>

      <main className="app-main">
        {/*form section to add/edit contacts*/}
        <section className="form-section">
          <h2>{editingId ? 'Edit Contact' : 'Add New Contact'}</h2>
          
          {error && <div className="alert alert-error">{error}</div>}
          {success && <div className="alert alert-success">{success}</div>}

          <form onSubmit={handleSubmit} className="contact-form">
            <div className="form-group">
              <label htmlFor="name">Name *</label>
              <input
                type="text"
                id="name"
                value={name}
                onChange={(e) => setName(e.target.value)}
                placeholder="Enter full name"
                required
              />
            </div>

            <div className="form-group">
              <label htmlFor="email">Email *</label>
              <input
                type="email"
                id="email"
                value={email}
                onChange={(e) => setEmail(e.target.value)}
                placeholder="Enter email address"
                required
              />
            </div>

            <div className="form-group">
              <label htmlFor="phone">Phone</label>
              <input
                type="text"
                id="phone"
                value={phone}
                onChange={(e) => setPhone(e.target.value)}
                placeholder="Enter phone number"
              />
            </div>

            <div className="form-group">
              <label htmlFor="company">Company</label>
              <input
                type="text"
                id="company"
                value={company}
                onChange={(e) => setCompany(e.target.value)}
                placeholder="Enter company name"
              />
            </div>

            <div className="form-group">
              <label htmlFor="notes">Notes</label>
              <textarea
                id="notes"
                value={notes}
                onChange={(e) => setNotes(e.target.value)}
                placeholder="Enter additional notes"
                rows="3"
              />
            </div>

            <div className="form-actions">
              <button type="submit" className="btn btn-primary">
                {editingId ? 'Update Contact' : 'Add Contact'}
              </button>
              {editingId && (
                <button type="button" className="btn btn-secondary" onClick={resetForm}>
                  Cancel
                </button>
              )}
            </div>
          </form>
        </section>

        {/*list section to view existing contacts*/}
        <section className="list-section">
          <h2>All Contacts ({contacts.length})</h2>
          {contacts.length === 0 ? (
            <p className="no-contacts">No contacts found. Add one on the left!</p>
          ) : (
            <div className="contacts-table-wrapper">
              <table className="contacts-table">
                <thead>
                  <tr>
                    <th>Name</th>
                    <th>Email</th>
                    <th>Phone</th>
                    <th>Company</th>
                    <th>Notes</th>
                    <th>Actions</th>
                  </tr>
                </thead>
                <tbody>
                  {contacts.map((contact) => (
                    <tr key={contact._id}>
                      <td className="font-semibold">{contact.name}</td>
                      <td>{contact.email}</td>
                      <td>{contact.phone || '-'}</td>
                      <td>{contact.company || '-'}</td>
                      <td className="notes-cell">{contact.notes || '-'}</td>
                      <td>
                        <div className="table-actions">
                          <button
                            onClick={() => handleEdit(contact)}
                            className="btn-action btn-edit"
                            title="Edit"
                          >
                            Edit
                          </button>
                          <button
                            onClick={() => handleDelete(contact._id)}
                            className="btn-action btn-delete"
                            title="Delete"
                          >
                            Delete
                          </button>
                        </div>
                      </td>
                    </tr>
                  ))}
                </tbody>
              </table>
            </div>
          )}
        </section>
      </main>
      
      <footer className="app-footer">
        <p>TechSphere CMS &copy; {new Date().getFullYear()} - Student DevOps/CI-CD Assignment</p>
      </footer>
    </div>
  );
}

export default App;
