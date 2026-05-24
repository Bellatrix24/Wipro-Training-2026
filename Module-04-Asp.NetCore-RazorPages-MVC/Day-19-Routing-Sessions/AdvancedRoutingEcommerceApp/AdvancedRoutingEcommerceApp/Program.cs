using AdvancedRoutingEcommerceApp.RouteConstraints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register the custom route constraints.
// Note: In modern ASP.NET Core, Program.cs is the single entry point and replaces the old Startup.cs system.
builder.Services.Configure<RouteOptions>(options =>
{
    options.ConstraintMap.Add("guidConstraint", typeof(GuidRouteConstraint));
    options.ConstraintMap.Add("categoryConstraint", typeof(CategoryRouteConstraint));
    options.ConstraintMap.Add("priceRangeConstraint", typeof(PriceRangeRouteConstraint));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

// Map advanced custom routes with our registered constraints

// 1. GUID Demo Route (using the GuidRouteConstraint)
app.MapControllerRoute(
    name: "guidDemo",
    pattern: "GuidDemo/{id:guidConstraint}",
    defaults: new { controller = "GuidDemo", action = "Details" });

// 2. Products Filter Route (using categoryConstraint and priceRangeConstraint)
app.MapControllerRoute(
    name: "productsFilter",
    pattern: "Products/Filter/{category:categoryConstraint}/{priceRange:priceRangeConstraint}",
    defaults: new { controller = "Products", action = "Filter" });

// 3. Product Details Route (using categoryConstraint)
app.MapControllerRoute(
    name: "productDetails",
    pattern: "Products/{category:categoryConstraint}/{id:int}",
    defaults: new { controller = "Products", action = "Details" });

// 4. User Orders Route
app.MapControllerRoute(
    name: "userOrders",
    pattern: "Users/{username}/Orders",
    defaults: new { controller = "Users", action = "Orders" });

// 5. Checkout Route
app.MapControllerRoute(
    name: "checkout",
    pattern: "Checkout",
    defaults: new { controller = "Checkout", action = "Index" });

// 6. Login Route
app.MapControllerRoute(
    name: "login",
    pattern: "Login",
    defaults: new { controller = "Login", action = "Index" });

// 7. Dashboard Route
app.MapControllerRoute(
    name: "dashboard",
    pattern: "Dashboard",
    defaults: new { controller = "Dashboard", action = "Index" });

// Default route for home landing catalog page
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Products}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
