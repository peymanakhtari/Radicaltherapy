function createReserve() {
    var valueNumber = document.getElementById('prefix').value + document.getElementById('number').value;
    var number = valueNumber.replace('-', '');
    document.getElementById('mobile').value = number;
    var valueName = document.getElementById("name").value;
    var name = valueName.replace('-', '');
    var date = document.getElementById("date").value;
    var shamsidate = document.getElementById('shamsidate').value;
    localStorage.setItem('reserve', number + ' - ' + name + ' - ' + shamsidate + ' -' + date);
}

function returnToMobile() {
    location.reload();
}
function ContinueReservation() {
    $('#name-validation').html('');
    $('#mobile-validation').html('');


    var IsValid = true;
    var massage = '';
    if ($('#name').val() == '') {
        massage = 'نام خود را وارد کنید';
        $('#name-validation').html(massage);
        return
    }
    if ($('#prefix').val() == '') {
        return
    }
    if (!$('#prefix').val().startsWith('+')) {
        massage = 'کد کشور با + شروع شود';
        $('#mobile-validation').html(massage);
        return
    }
    if ($('#number').val() == '' || ($('#number').val().length < 8 || $('#number').val().length > 12)) {
        massage = 'موبایل اشتباه است';
        $('#mobile-validation').html(massage);
        return
    }
    if (!IsValid) {
        return
    }
    else {
        window.scrollTo(0, 0);
        localStorage.setItem('name', $('#name').val())
        localStorage.setItem('number', $('#number').val())
        localStorage.setItem('prefix', $('#prefix').val())

        $('#name-validation').html('');
        $('#mobile-validation').html('');
        $('#select-reserve').css('display', 'none');
        $('.question-box').css('display', 'block');
        var number = document.getElementById('prefix').value + document.getElementById('number').value;
        document.getElementById('mobile').value = number;

    }



}



function questionValidation() {
    $('.question').css('background', 'white');
    $('.question').css('color', 'black');
    var result = false;
    for (let index = 1; index < 26; index++) {
        if (localStorage.getItem('q' + index) == null || localStorage.getItem('q' + index) == '') {
            $('#q' + index).css('background', 'red')
            $('#q' + index).css('color', 'white')
            result = true
        }
    }
    if (result) {
        alert('لطفا به تمامی سوالات پاسخ دهید')
    }
    else {
        $('#btnSubmitReserve').html('کمی صبر کنید...');
        $('#btnSubmitReserve').attr('disabled', 'disabled');
        for (let index = 1; index < 26; index++) {
            var radios = document.getElementsByName("q" + index);
            var val = localStorage.removeItem('q' + index);
        }

        localStorage.removeItem('name');
        localStorage.removeItem('number');
        localStorage.removeItem('prefix');
        createReserve();
        document.getElementById("myForm").submit();

    }
}
$(document).ready(function () {
    $('#name').val(localStorage.getItem('name'));
    $('#number').val(localStorage.getItem('number'));


    if (localStorage.getItem('prefix') != null) {
        $('#prefix').val(localStorage.getItem('prefix'));
    }

    for (let index = 1; index < 26; index++) {
        var radios = document.getElementsByName("q" + index);
        var val = localStorage.getItem('q' + index);
        for (var idx = 0; idx < radios.length; idx++) {
            if (radios[idx].value == val) {
                radios[idx].checked = true;
            }
        }
    }
    var input1 = document.getElementsByName("q1")[0];
    input1.value = localStorage.getItem('q1');
    var input5 = document.getElementsByName('q5')[0];
    input5.value = localStorage.getItem('q5');
    var input6 = document.getElementsByName('q6')[0];
    input6.value = localStorage.getItem('q6');



    $('input[name="q1"]').on('focusout', function () {
        localStorage.setItem('q1', $(this).val());
    })

    $('input[name="q2"]').on('change', function () {
        localStorage.setItem('q2', $(this).val());
    })

    $('input[name="q3"]').on('change', function () {
        localStorage.setItem('q3', $(this).val());
    })

    $('input[name="q4"]').on('change', function () {
        localStorage.setItem('q4', $(this).val());
    })

    $('input[name="q5"]').on('focusout', function () {
        localStorage.setItem('q5', $(this).val());
    })

    $('input[name="q6"]').on('focusout', function () {
        localStorage.setItem('q6', $(this).val());
    })

    $('input[name="q7"]').on('change', function () {
        localStorage.setItem('q7', $(this).val());
    })

    $('input[name="q8"]').on('change', function () {
        localStorage.setItem('q8', $(this).val());
    })

    $('input[name="q9"]').on('change', function () {
        localStorage.setItem('q9', $(this).val());
    })

    $('input[name="q10"]').on('change', function () {
        localStorage.setItem('q10', $(this).val());
    })

    $('input[name="q11"]').on('change', function () {
        localStorage.setItem('q11', $(this).val());
    })

    $('input[name="q12"]').on('change', function () {
        localStorage.setItem('q12', $(this).val());
    })

    $('input[name="q13"]').on('change', function () {
        localStorage.setItem('q13', $(this).val());
    })
    $('input[name="q14"]').on('change', function () {
        localStorage.setItem('q14', $(this).val());
    })
    $('input[name="q15"]').on('change', function () {
        localStorage.setItem('q15', $(this).val());
    })
    $('input[name="q16"]').on('change', function () {
        localStorage.setItem('q16', $(this).val());
    })
    $('input[name="q17"]').on('change', function () {
        localStorage.setItem('q17', $(this).val());
    })
    $('input[name="q18"]').on('change', function () {
        localStorage.setItem('q18', $(this).val());
    })
    $('input[name="q19"]').on('change', function () {
        localStorage.setItem('q19', $(this).val());
    })
    $('input[name="q20"]').on('change', function () {
        localStorage.setItem('q20', $(this).val());
    })
    $('input[name="q21"]').on('change', function () {
        localStorage.setItem('q21', $(this).val());
    })
    $('input[name="q22"]').on('change', function () {
        localStorage.setItem('q22', $(this).val());
    })
    $('input[name="q23"]').on('change', function () {
        localStorage.setItem('q23', $(this).val());
    })
    $('input[name="q24"]').on('change', function () {
        localStorage.setItem('q24', $(this).val());
    })
    $('input[name="q25"]').on('change', function () {
        localStorage.setItem('q25', $(this).val());
    })

});
$(document).ready(function () {
    document.getElementById('preReservation-link').style.display = 'none';
})
