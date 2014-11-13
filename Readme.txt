-------------------------------------------
Name: Bootswatch Theme, Selector Plugin
Author: Huy Mach
NopVersion: 2.8
---------------Set Up-----------------------
1. Copy bootswatch.nop.theme into "/Nop.Web/Themes"
2. Copy Selector into "Plugins" folder and login with admin, 
go to /Configuration/Plugins and install.
3. i Added Fly To Cart which is plus, you want to use it. 
Just extra some code
+ Open /Nop.Web/Controllers/ShoppingCartController.cs
+ Find to "AddProductToCart"
+ Roll to return of the method which is 
return Json(new
{
   success = true,
   message = string.Format(_localizationService.GetResource("Products.ProductHasBeenAddedToTheCart.Link"), Url.RouteUrl("ShoppingCart")),
   updatetopcartsectionhtml = updatetopcartsectionhtml,
   updateflyoutcartsectionhtml = updateflyoutcartsectionhtml
});

+ change into
return Json(new
{
   success = true,
   productId = productId,
   message = string.Format(_localizationService.GetResource("Products.ProductHasBeenAddedToTheCart.Link"), Url.RouteUrl("ShoppingCart")),
   updatetopcartsectionhtml = updatetopcartsectionhtml,
   updateflyoutcartsectionhtml = updateflyoutcartsectionhtml
});
+ Next, find to "AddProductVariantToCart"
+ change into 
return Json(new
{
   success = true,
   productId = productVariantId,
   message = string.Format(_localizationService.GetResource("Products.ProductHasBeenAddedToTheCart.Link"), Url.RouteUrl("ShoppingCart")),
   updatetopcartsectionhtml = updatetopcartsectionhtml,
   updateflyoutcartsectionhtml = updateflyoutcartsectionhtml
});
+ that's all.

Thank you!