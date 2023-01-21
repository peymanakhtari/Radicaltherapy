var
    persianNumbers = [/۰/g, /۱/g, /۲/g, /۳/g, /۴/g, /۵/g, /۶/g, /۷/g, /۸/g, /۹/g],
    arabicNumbers = [/٠/g, /١/g, /٢/g, /٣/g, /٤/g, /٥/g, /٦/g, /٧/g, /٨/g, /٩/g],
    fixNumbers = function (str) {
        if (typeof str === 'string') {
            for (var i = 0; i < 10; i++) {
                str = str.replace(persianNumbers[i], i).replace(arabicNumbers[i], i);
            }
        }
        return str;
    };
function setLink(Val) {
    var id = Val.split('-')[1];
    var newnum = document.getElementById('mobile-' + id).value;
    $.ajax({
        type: "POST",
        url: '/Admin/SetLink',
        data: {
            "Id": id,
            "number": newnum
        },
        success: function (response) {
            location.reload();
        }, error: function (response) {

            alert('شماره ست نشد')
        }
    })
}

function raducesize(){
    
    var imgFile=document.getElementById('formPic').files[0];

    convertToBase64(imgFile).then(
        data => document.getElementById('imgReseptbig').src = data
      );
      convertToBase64(imgFile).then(
        data => document.getElementById('base64pic').value = resizeImage(data)
      );

}
