﻿//show password_Login page
function myFunction() {
    var x = document.getElementById("myInput");
    if (x.type === "password") {
        x.type = "text";
    } else {
        x.type = "password";
    }
}
$(document).ready(function () {

    $("#togglemenu").click(function () {
        $("#collapsibleNavbar").slideToggle("fast");

    });
    // Optimalisation: Store the references outside the event handler:
    var $window = $(window);
    var $pane = $('#collapsibleNavbar');
    var $menu_icon = $("#togglemenu");

    function checkWidth_onload() {
        var windowsize = $window.width();
        if (windowsize > 890) {
            $menu_icon.hide();
            $pane.show();
        }
    }

    function checkWidth_onResize() {

        var windowsize = $window.width();
        if (windowsize < 890) {
            $pane.hide();
            $menu_icon.show();

        } else {

            $pane.show();
            $menu_icon.hide();
        }
    }
    // Execute on load
    checkWidth_onload();
    // Bind event listener
    $(window).resize(checkWidth_onResize);
});


$(document).on("click", function (event) {

    var $window = $(window);
    if ($(window).width() < 890) {
        var $trigger = $(".menu-container");
        if ($trigger !== event.target && !$trigger.has(event.target).length) {
            $("#collapsibleNavbar").slideUp("fast");
        }
    }

});


/*--------------fixed bottm navbar-----------------*/
var navItems = document.querySelectorAll(".mobile-bottom-nav__item");
navItems.forEach(function (e, i) {
    e.addEventListener("click", function (e) {
        navItems.forEach(function (e2, i2) {
            e2.classList.remove("mobile-bottom-nav__item--active");
        })
        this.classList.add("mobile-bottom-nav__item--active");
    });
});

function getCookie(name) {
    var nameEQ = name + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') c = c.substring(1, c.length);
        if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
    }
    return null;
}

function setCookie(name, value, days) {
    var expires = "";
    if (days) {
        var date = new Date();
        date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
        expires = "; expires=" + date.toUTCString();
    }
    document.cookie = name + "=" + (value || "") + expires + "; path=/";
}

$(".custom-file-input").on("change", function () {
    var fileName = $(this).val().split("\\").pop();
    $(this).siblings(".custom-file-label").addClass("selected").html(fileName);
});

function convertToBase64(file, cb) {
    var reader = new FileReader();
    reader.onload = function (e) {
        cb(null, e.target.result)
    };
    reader.onerror = function (e) {
        cb(e);
    };
    reader.readAsDataURL(file);
}



function inputFileChange() {
    var imgFile = document.getElementById('resept_input').files[0];

    $('#resept-box').replaceWith(function () {
        return $(`<div style="color:white;padding:8px 2rem;border-radius:4px;" id="uploading" class="bg-secondary">...در حال بارگذاری</div>`, { html: $(this).html() });
    });
    convertToBase64(imgFile, function (err, data) {
        document.getElementById('imgResept').src = data;
        document.getElementById('imgReseptbig').src = data;

        if (err) {
            alert(err)
            return;
        }

        $('#ReseptPhoto').removeClass('d-none');
        $('#uploading').addClass('d-none');
        

    });
};
function resizeImage(base64Str) {
    var img = new Image();
    img.src = base64Str;
    var canvas = document.createElement('canvas');
    var MAX_WIDTH = 600;
    var MAX_HEIGHT = 600;
    var width = document.getElementById('imgReseptbig').width;
    var height = document.getElementById('imgReseptbig').height;
    if (width > height) {
        if (width > MAX_WIDTH) {
            height *= MAX_WIDTH / width;
            width = MAX_WIDTH;
        }
    } else {
        if (height > MAX_HEIGHT) {
            width *= MAX_HEIGHT / height;
            height = MAX_HEIGHT;
        }
    }
    canvas.width = width;
    canvas.height = height;
    var ctx = canvas.getContext('2d');
    ctx.drawImage(img, 0, 0, width, height);
    return canvas.toDataURL();
}
function deleteResept() {
    location.reload();
}

function submitReserve() {

    if (!document.getElementById('customCheck').checked) {
        $('#isNotChecked').css('display', 'block');
    }
    else if ($('#ReseptPhoto').hasClass("d-none")) {
        $('#isNotChecked').css('display', 'none');
        $('#Uploadresept').css('display', 'block');
    }
    else {
        $('#btnSubmintBankResept').replaceWith(function () {
            return $(`      <button dir="rtl" id="submitbtnWaiting" style="min-width:8rem;font-family:Shabnam;font-weight:bold;" class="btn btn-success" disabled>
                      کمی صبر کنید  <span style="margin-bottom:6px;margin-right:4px" class="spinner-border spinner-border-sm "></span>
                  </button>`, { html: $(this).html() });
        });
        var data = resizeImage($('#imgReseptbig').attr('src'));
        $.ajax({
            url: '/User/SubmitRadicalReserve',
            type: 'POST',
            data: {img:data},
            success: function ($data) {
                location.reload();
            }
        })
    }
}

function replacebtn() {
    var input = document.getElementById('inputUsername');
    if (input.validity.valid) {
        $('#submitbtn').css('display', 'none');
        $('#submitbtnWaiting').css('display','block')
    }

}
function removebtnChooseThisTime() {
        $('#btnChooseThisTime').addClass('d-none');
        $('#submitbtnWaiting').removeClass('d-none');
}