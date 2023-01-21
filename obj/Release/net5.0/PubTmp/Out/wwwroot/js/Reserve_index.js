function test(value) {
    document.getElementById('p1').innerText = value;
}

$(document).ready(function () {

    if (localStorage.getItem('reserve') != null) {

        var cookievalue = localStorage.getItem('reserve');
        var values = cookievalue.split('-');
        var stringDateTime = values[3].split(' ');
        var strDate = stringDateTime[0];
        var Dateval = strDate.split('/');
        var strTime = stringDateTime[1];
        var Timeval = strTime.split(':');
        var reserveDateTime = new Date(Dateval[2], Dateval[0] - 1, Dateval[1], Timeval[0], Timeval[1]);
        var Now = new Date();
        var todaty = new Date(Now.getFullYear(), Now.getMonth(), Now.getDate());
        //--------------------------------check reserve datetime--------------------------------------

        if (reserveDateTime > todaty) {

            document.getElementById('reserveInfo').style.display = 'block';
            document.getElementById('select-reserve').style.display = 'none';
            document.getElementById('video-reserve').style.display = 'none';
            //----------------get reserve informaion from cookie-----------------
            document.getElementById('number').innerHTML = values[0];
            document.getElementById('name').innerHTML = values[1];
            var date = values[2].split(',');

            var dateinfo;
            if (date[3] == 0) {
                dateinfo = date[0] + '&nbsp;&nbsp;&nbsp;' + date[1] + ' ' + date[2] + '&nbsp;&nbsp;&nbsp; ساعت ' + date[4];

            }
            else {
                dateinfo = date[0] + '&nbsp;&nbsp;&nbsp;' + date[1] + ' ' + date[2] + '&nbsp;&nbsp;&nbsp; ساعت ' + date[3] + ' : ' + date[4];

            }
            document.getElementById('dateinfo').innerHTML = dateinfo;

            //----------------message if other time select-----------------
            $('.hour').attr('href', '#');
            $('.hour').click(function () {
                document.getElementById("messageChooseOtherTime").style.display = "block";
            });
            //----------------delete reserve-----------------
            $('#deleteReserve').click(function () {
                var res = {};
                res.Name = values[1];
                res.Mobile = values[0];
                res.Datetime = values[3];

                $.ajax({
                    type: "POST",
                    url: '/Reserve/Delete',
                    data: {"name":values[1],"mobile":values[0],"datetime":values[3]},
                    success: function () {
                        //----------------after reserve is delete-----------------
                        localStorage.removeItem('reserve')
                        location.replace(window.location.pathname + '?message=رزرو شما حذف شد');
                    },
                    error: function () {
                        alert("رزرو شما حذف نشد");
                    }
                });
            });
        }
        else {
            localStorage.removeItem('reserve')
        }
    }
});

window.onload = function () {
    document.getElementById('reserveDeleted').innerHTML = getParameterByName('message');

};
