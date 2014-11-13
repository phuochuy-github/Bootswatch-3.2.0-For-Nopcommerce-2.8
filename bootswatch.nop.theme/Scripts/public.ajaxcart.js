/*
** nopCommerce ajax cart implementation
*/


var AjaxCart = {
    loadWaiting: false,
    usepopupnotifications: false,
    topcartselector: '',
    topwishlistselector: '',
    flyoutcartselector: '',
    idproduct: '',

    init: function (usepopupnotifications, topcartselector, topwishlistselector, flyoutcartselector) {
        this.loadWaiting = false;
        this.usepopupnotifications = usepopupnotifications;
        this.topcartselector = topcartselector;
        this.topwishlistselector = topwishlistselector;
        this.flyoutcartselector = flyoutcartselector;
    },

    setLoadWaiting: function (display) {
        displayAjaxLoading(display);
        this.loadWaiting = display;
    },

    addproducttocart: function (urladd) {
        if (this.loadWaiting != false) {
            return;
        }
        this.setLoadWaiting(true);
        $.ajax({
            cache: false,
            url: urladd,
            type: 'post',
            success: this.successprocess,
            complete: this.resetLoadWaiting,
            error: this.ajaxFailure
        });
    },

    addproductvarianttocart: function (urladd, formselector) {
        if (this.loadWaiting != false) {
            return;
        }
        this.setLoadWaiting(true);
        $.ajax({
            cache: false,
            url: urladd,
            data: $(formselector).serialize(),
            type: 'post',
            success: this.successprocess,
            complete: this.resetLoadWaiting,
            error: this.ajaxFailure
        });
    },

    successprocess: function (response) {
        if (response.updatetopcartsectionhtml) {
            //*********Place Changed**********
            if ($("#img-item-" + response.productId).length != 0) {
                var cart = $(AjaxCart.topcartselector);
                var img = $("#img-item-" + response.productId);
                var img_clone = img.clone().offset({ left: img.offset().left, top: img.offset().top }).css({
                    'opacity': '0.5',
                    'position': 'absolute',
                    'height': '100px',
                    'width': '100px',
                    'z-index': '100'
                }).appendTo($('body')).animate({
                    'top': cart.offset().top,
                    'left': cart.offset().left,
                    'width': 75,
                    'height': 75
                }, 1000);

                img_clone.animate({
                    'width': 0,
                    'height': 0
                }, function () {
                    //$(this).remove();
                    $(this).detach();
                    cart.parent().effect("pulsate");
                });
            }
            //*********Place Changed**********
            $(AjaxCart.topcartselector).html(response.updatetopcartsectionhtml);
        }
        if (response.updatetopwishlistsectionhtml) {
            //*********Place Changed**********
            if ($("#img-item-" + response.productId).length != 0) {
                var cart = $(AjaxCart.topwishlistselector);
                var img = $("#img-item-" + response.productId);
                var img_clone = img.clone().offset({ left: img.offset().left, top: img.offset().top }).css({
                    'opacity': '0.5',
                    'position': 'absolute',
                    'height': '100px',
                    'width': '100px',
                    'z-index': '100'
                }).appendTo($('body')).animate({
                    'top': cart.offset().top,
                    'left': cart.offset().left,
                    'width': 75,
                    'height': 75
                }, 1000);

                img_clone.animate({
                    'width': 0,
                    'height': 0
                }, function () {
                    //$(this).remove();
                    $(this).detach();
                    cart.parent().effect("pulsate");
                });
            }
            //*********Place Changed**********
            $(AjaxCart.topwishlistselector).html(response.updatetopwishlistsectionhtml);
        }
        if (response.updateflyoutcartsectionhtml) {
            $(AjaxCart.flyoutcartselector).replaceWith(response.updateflyoutcartsectionhtml);
        }
        
        if (response.message) {
            //display notification
            if (response.success == true) {
                //success
                if (AjaxCart.usepopupnotifications == true) {
                    displayPopupNotification(response.message, 'success', true);
                }
                else {
                    //specify timeout for success messages
                    displayBarNotification(response.message, 'success', 3500);
                }
            }
            else {
                //error
                if (AjaxCart.usepopupnotifications == true) {
                    displayPopupNotification(response.message, 'error', true);
                }
                else {
                    //no timeout for errors
                    displayBarNotification(response.message, 'error', 0);
                }
                
            }
            return false;
        }
        if (response.redirect) {
            location.href = response.redirect;
            return true;
        }
        return false;
    },

    resetLoadWaiting: function () {
        AjaxCart.setLoadWaiting(false);
    },

    ajaxFailure: function () {
        alert('Failed to add the product to the cart. Please refresh the page and try one more time.');
    }
};