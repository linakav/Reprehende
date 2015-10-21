//Search effects

var searchForm = $('.search_form');
var searchTxt = $('.search_txt');

searchForm.on('mouseenter', function () {
    searchTxt.addClass('hovered');
	});
searchForm.on('mouseleave', function () {
    searchTxt.removeClass('hovered');
	});
searchTxt.on('focus', function () {
    searchTxt.addClass('focused');
	});
searchTxt.on('focusout', function () {
    searchTxt.removeClass('focused');
});

//Banner effects

var img = $('div .img');
var bannerTextBackgrounds = $('.text_background');

img.on('mouseenter', function() {
    $(this).find('.text_background').addClass('opened');
	});
img.on('mouseleave', function() {	
    $(this).find('.text_background').removeClass('opened');
	});

//Slider loader
$(document).ready(function () {
    var owlCarousel = $('#owl-demo');
    if (owlCarousel.length) {
        owlCarousel.owlCarousel({

            navigation: false,
            paginationSpeed: 800,
            singleItem: true,
            autoPlay: true,
            stopOnHover: true,
            lazyLoad: true,
            mouseDrag: false

        });
    }
});

//Left Menu effects

var leftMenuOpenClose = $('.open_close');

leftMenuOpenClose.on('click', function (e) {
    var subcategories = $(this).parents('.left_menu_item');

    if (subcategories.hasClass('expanded')) {
        $(this).html('+');
        subcategories.removeClass('expanded');
    }
    else {
        $(this).html('-');
        subcategories.addClass('expanded');
    }
    return false;
});

// Forgot Password Form hide/show
var forgotPasswordOpen = $('.forgot_password_link.open');
var forgotPasswordWrapper = $('.forgot_password_wrapper');

forgotPasswordOpen.on('click', function (e) {

    if (forgotPasswordWrapper.hasClass('closed')) {
        forgotPasswordWrapper.removeClass('closed');
    }
});

var forgotPasswordClose = $('.forgot_password_link.close');

forgotPasswordClose.on('click', function (e) {
    forgotPasswordWrapper.addClass('closed');
    return false;
});

//Email Validation

function validateEmail(email) {
    if (email.match(/^[\w.%+-]+@[\w.-]+\.[A-Z]{2,4}$/i) != null) {
        return true;
    }
    else {
        return false;
    }
}

//Newsletter Submittion handling

var newsletterForm = $('.newsletter_form');

newsletterForm.on('submit', function (e) {
    e.preventDefault();
    var currentValue = $('.nl_inp').val().trim();
    var newsletterMessages = $('.newsletter_form .message');

    if (currentValue == '') {
        newsletterMessages.hide();
        $('.newsletter_form .empty_error').show();
    }
    else if (validateEmail(currentValue)) {
        newsletterMessages.hide();
        $.ajax({
            type: "POST",
            url: "/services/NewsletterSubscription.asmx/SubscriptionRequest",
            data: "{'email':'" + currentValue + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                if (data.d) {
                    newsletterMessages.hide();
                    $('.newsletter_form .newsletter_success').show()
                }
                else {
                    newsletterMessages.hide();
                    $('.newsletter_form .duplicate_error').show()
                }
            },
            error: function (e) {
                $('.newsletter_form .generic_error').show();
            }
        });
    }
    else {
        newsletterMessages.hide();
        $('.newsletter_form .invalid_error').show();
    }
});

//Register Form Submittion handling

var registerForm = $('.register .form');

registerForm.on('submit', function (e) {
    e.preventDefault();

    var loading = $('.register .loading');
    var password = $('.register .form .password');
    var passwordConfirm = $('.register .form .password_confirm');
    var email = $('.register .form .email');
    var continueFlag = 1;
    var registerValidators = $('.register .message');
    var requiredFields = $('.register .form .required .input');

    loading.show();
    registerValidators.hide();

    if (!validateEmail(email.val().trim())) {
        email.siblings('.message').hide();
        $('.register .form .invalid_error').css('display', 'block');
        continueFlag = 0;
    }


    if (password.val() != passwordConfirm.val()) {
        passwordConfirm.siblings('.message').hide();
        $('.register .form .not_same_error').css('display', 'block');
        continueFlag = 0;
    }

    requiredFields.each(function (index) {
        currentValue = $(this).val().trim();
        if (currentValue == '') {
            $(this).siblings('.message').hide();
            $(this).siblings('.empty_error').css('display', 'block');
            continueFlag = 0;
        }
    });

    if (continueFlag) {
        var firstName = $('.register .form .first_name').val();
        var lastName = $('.register .form .last_name').val();
        var email = email.val().trim();
        var password = password.val();
        var newsletterRegister = $('.register .form .newsletter_ckb').is(':checked');

        if (newsletterRegister) {
            $.ajax({
                type: "POST",
                url: "/services/NewsletterSubscription.asmx/SubscriptionRequest",
                data: "{'email':'" + email + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                },
                error: function (e) {
                    $('.register .generic_error').css('display', 'block');
                }
            });
        }
        
        $.ajax({
            type: "POST",
            url: "/services/UserRegistration.asmx/RegistrationRequest",
            data: "{'firstName':'" + firstName + "','lastName':'" + lastName + "','email':'" + email + "','password':'" + password + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                if (data.d == "success") {
                    $('.register .form_description_wrapper').hide();
                    $('.register .success_wrapper').css('display', 'block');
                    //localStorage['userID'] = data.d;
                    setLoginLogoutStatus();
                }
                else if (data.d == "duplicate") {
                    $('.register .account_exists').css('display', 'block');
                }
                else {

                }
                loading.hide();
            },
            error: function (e) {
                $('.register .generic_error').css('display', 'block');
                loading.hide();
            }
        });
    }
    else { loading.hide(); }
});

var logout = $('.header_wrapper .logout');
var login = $('.header_wrapper .login');

function setLoginLogoutStatus() {
    if (localStorage['userID'] != null) {
        login.hide();
        logout.show();
    }
    else {
        logout.hide();
        login.show();
    }
};

logout.on('click', function () {
    localStorage.removeItem('userID');
    setLoginLogoutStatus();
});