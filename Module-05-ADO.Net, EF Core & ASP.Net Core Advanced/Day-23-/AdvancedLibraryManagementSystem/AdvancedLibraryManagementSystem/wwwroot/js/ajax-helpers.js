// ajax-helpers.js
// Shared AJAX functions used by all pages

function showAlert(message, type) {
    var box = document.getElementById('alertBox');
    box.className = 'alert alert-' + type;
    box.textContent = message;
    setTimeout(function () { box.className = 'd-none'; }, 3000);
}

function refreshMainContent() {
    fetch(window.location.href)
        .then(function (r) { return r.text(); })
        .then(function (html) {
            var doc = new DOMParser().parseFromString(html, 'text/html');
            var newContent = doc.getElementById('mainContent');
            if (newContent) {
                document.getElementById('mainContent').innerHTML = newContent.innerHTML;
            }
        })
        .catch(function () {
            showAlert('Saved, but the list could not be refreshed.', 'warning');
        });
}

// Load a form partial into the shared modal and show it
function loadForm(url, title) {
    document.getElementById('modalTitle').textContent = title;
    document.getElementById('modalBody').innerHTML = 'Loading...';

    var modal = new bootstrap.Modal(document.getElementById('ajaxModal'));
    modal.show();

    fetch(url)
        .then(function (r) { return r.text(); })
        .then(function (html) {
            document.getElementById('modalBody').innerHTML = html;
            attachFormSubmit();
        })
        .catch(function () {
            document.getElementById('modalBody').innerHTML = 'Failed to load form.';
        });
}

// Attach AJAX submit to the form loaded in the modal
function attachFormSubmit() {
    var form = document.querySelector('#modalBody form');
    if (!form) return;

    form.addEventListener('submit', function (e) {
        e.preventDefault();
        var data = new FormData(form);

        fetch(form.action, { method: 'POST', body: data })
            .then(function (r) { return r.json(); })
            .then(function (result) {
                if (result.success) {
                    bootstrap.Modal.getInstance(document.getElementById('ajaxModal')).hide();
                    showAlert(result.message, 'success');
                    refreshMainContent();
                } else {
                    showAlert(result.message || 'Something went wrong.', 'danger');
                }
            })
            .catch(function () {
                showAlert('Request failed. Please try again.', 'danger');
            });
    });
}

// Delete an item by posting to the delete URL, then remove its table row
function deleteItem(url, rowId) {
    if (!confirm('Are you sure you want to delete this?')) return;

    var token = document.querySelector('#antiForgeryForm input[name="__RequestVerificationToken"]');
    var body = new FormData();
    if (token) body.append('__RequestVerificationToken', token.value);

    fetch(url, { method: 'POST', body: body })
        .then(function (r) { return r.json(); })
        .then(function (result) {
            if (result.success) {
                var row = document.getElementById(rowId);
                if (row) row.remove();
                showAlert(result.message, 'success');
            } else {
                showAlert(result.message || 'Delete failed.', 'danger');
            }
        })
        .catch(function () {
            showAlert('Delete request failed.', 'danger');
        });
}
