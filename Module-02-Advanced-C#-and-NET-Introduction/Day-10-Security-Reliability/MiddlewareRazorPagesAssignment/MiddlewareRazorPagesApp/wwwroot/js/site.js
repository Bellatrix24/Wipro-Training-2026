// Client-side scripting validating static integration
document.addEventListener("DOMContentLoaded", () => {
    const alertBtn = document.getElementById("alert-btn");
    
    if (alertBtn) {
        alertBtn.addEventListener("click", () => {
            alert("Static JS script successfully loaded under local CSP rules!");
            console.log("Interactive script run was verified.");
        });
    }
});
