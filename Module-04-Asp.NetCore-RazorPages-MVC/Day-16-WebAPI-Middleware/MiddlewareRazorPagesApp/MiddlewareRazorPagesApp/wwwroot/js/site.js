// Natural comment: Simple JS file to verify that script files are loaded and executed.
document.addEventListener("DOMContentLoaded", function () {
    console.log("Static JavaScript file successfully loaded and executed from wwwroot/js/site.js!");
    
    // Update status badge on index.html once loaded successfully
    var jsStatusBadge = document.getElementById("js-status");
    if (jsStatusBadge) {
        jsStatusBadge.textContent = "Served";
        jsStatusBadge.className = "badge success";
    }
});
