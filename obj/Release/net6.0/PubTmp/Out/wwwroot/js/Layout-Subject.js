
$(document).ready(function () {
    if (getParameterByName('element')!=undefined) {
        var element = document.getElementById(getParameterByName('element'));
        scorollToElement(element);

    }

    //scroll to
    if (getParameterByName('CommentIsDelete') != undefined) {
        var deleteElem = document.getElementById('deletedComment');
        deleteElem.style.display = "block";
        scorollToElement(deleteElem);
    }

    var commentsId = localStorage.getItem("comment").split('-');
    commentsId.forEach(myFunction);
    function myFunction(item, index) {
        try {
            document.getElementById("askDelte-" + item).style.display = 'block';
        } catch (e) {

        }
        try {
            document.getElementById("commentResponse-" + item).style.display = 'block';
        } catch (e) {

        }

    }
});

function scorollToElement(element) {
    element.scrollIntoView({ block: "center" });
}



function validation(value,id) {
    if (value.trim() === "") {
        document.getElementById(id).style.display = 'inline-block';
        return false
    }
    else {
        document.getElementById(id).style.display = 'none';
        return true;
    }
}

function askDelete(Val) {
    var id = Val.split('-')[1];
    document.getElementById("deleteCmt-" + id).style.display = "block";
}

function NotDelete(Val) {
    var id = Val.split('-')[1];
    document.getElementById("deleteCmt-" + id).style.display = "none";
}



function deleteComment(Val) {
    var id = Val.split('-')[1];
    var subjectId = document.getElementById('subjectId').value;
    $.ajax({
        type: "POST",
        url: '/Subjects/DeleteComment',

        data: {
            "Id": id
        },
        success: function (value) {
            if (value=='affectLocalStorage') {
                if (localStorage.getItem("comment").includes('-')) {
                    var value = localStorage.getItem("comment");
                    newvalue= value.replace('-' + id, '');
                    localStorage.setItem('comment', newvalue);
                }
            }
            location.replace(window.location.pathname + '?CommentIsDelete=DeletedComment' + '&' + 'subjectId=' + subjectId);
        },
        error: function () {
            alert('نظر حذف نشد')
        }
    });
}

function UpdateComment(Val) {
    var id = Val.split('-')[1];
    var newtext = document.getElementById("updateText-" + id).value;
    var subjectId = document.getElementById('subjectId').value;

    if (validation(newtext, 'newtextValidation-' + id)) {
        $("#updateComment-" + id).prop("disabled", true);
        $("#updateComment-" + id).val("کمی صبر کنید...");

        $.ajax({
            type: "POST",
            url: '/Subjects/UpdateComment',
            data: {
                "Id": id,
                "newtext": newtext
            },
            success: function (response) {
                location.replace(window.location.pathname + '?element=TextCmt-' + id + '-Last' + '&' + 'subjectId=' + subjectId);
            },
            error: function (response) {

                alert('نظر ثبت نشد')
            }
        });
    }

}


function addComment() {

    var text = document.getElementById('newComment').value;
    var username = document.getElementById('username').value;
    var subjectId = document.getElementById('subjectId').value;
    var auth = null;
    var p256dh = null;
    var endpoint = null;
    try {
        if (Notification.permission === "granted") {
            auth = localStorage.getItem('auth000');
            endpoint = localStorage.getItem('endpoint000');
            p256dh = localStorage.getItem('p256dh000');
        }

    } catch (e) {
     
    }
    if (validation(text, 'NewCmtTextValidation')) {
        if (validation(username, 'NewCmtNameValidation')) {
            $("#AddNewComment").prop("disabled", true);
            $("#AddNewComment").val("کمی صبر کنید...");
            $.ajax({
                type: "POST",
                url: '/Subjects/AddComment',
                data: {
                    "text": text,
                    "username": username,
                    "subjectId": subjectId,
                    "auth": auth,
                    "endpoint": endpoint,
                    "p256dh": p256dh
                },
                success: function (id) {
                    if (localStorage.getItem("comment") === null) {
                        localStorage.setItem("comment", id);
                    } else {
                        var currentComments = localStorage.getItem("comment");
                        var newComments = currentComments + "-" + id;
                        localStorage.setItem("comment", newComments);
                    }
                    location.replace(window.location.pathname + '?element=TextCmt-' + id + '-Last');
                },
                error: function () {
                    alert('نظر ثبت نشد')
                }
            });
        }
    }

}

if ('serviceWorker' in navigator) {
    window.addEventListener("load", () => {
        navigator.serviceWorker.register("/ServiceWorker.js")
            .then((reg) => {
                if (Notification.permission === "granted") {
                    $(".giveAccess").css("display", "none");
                    $(".Isblock").css("display", "none");
                } else if (Notification.permission === "blocked") {
                    $(".giveAccess").css("display", "none");
                    $(".Isblock").css("display", "block");
                } else {
                    $(".giveAccess").css("display", "block");
                    $(".Isblock").css("display", "none");
                }
            });
    });
} else {
    $(".giveAccess").css("display", "none");
    $(".Isblock").css("display", "none");
}

function requestNotificationAccess(Val) {

    Notification.requestPermission(function (status) {

        if (status == "granted") {

            IsNotificatinAllow(Val);
            $(".giveAccess").css("display", "none");
            $(".hasAccess").css("display", "block");

        } else {
            $(".giveAccess").css("display", "none");
            $(".Isblock").css("display", "block");
        }
    });
}

function AccessIsBlock(Val) {

    Notification.requestPermission(function (status) {

        if (status == "granted") {

            IsNotificatinAllow(Val);
            $(".Isblock").css("display", "none");
            $(".hasAccess").css("display", "block");


        } else {
            window.location.href = "/Home/ActiveNotification";
        }
    });
}

function IsNotificatinAllow(Val) {
    navigator.serviceWorker.register("/ServiceWorker.js")
        .then((reg) => {
            reg.pushManager.getSubscription().then(function (sub) {
                if (sub === null) {
                    reg.pushManager.subscribe({
                        userVisibleOnly: true,
                        /**/
                        applicationServerKey: "BI3xMbriuQ8IReKLWBZOADVA0-4hSWjDUnc0q3amFNhrJc06S4uBavwoRkEWzcagqr6YyBvOZAbv8hNvxGNUO_Y"
                        /**/
                    }).then(function (sub) {
                        var auth = arrayBufferToBase64(sub.getKey("auth"));
                        var p256dh = arrayBufferToBase64(sub.getKey("p256dh"));
                        var endpoint = sub.endpoint
                        localStorage.setItem('auth000', auth);
                        localStorage.setItem('p256dh000', p256dh);
                        localStorage.setItem('endpoint000', endpoint);
                        addClient(auth, p256dh, endpoint, Val)
                        
                    }).catch(function (e) {
                        console.error("Unable to subscribe to push", e);
                    });
                } else {
                    var auth = arrayBufferToBase64(sub.getKey("auth"));
                    var p256dh = arrayBufferToBase64(sub.getKey("p256dh"));
                    var endpoint = sub.endpoint
                    localStorage.setItem('auth000', auth);
                    localStorage.setItem('p256dh000', p256dh);
                    localStorage.setItem('endpoint000', endpoint);
                    addClient(auth, p256dh, endpoint, Val)
                }
            });

        })

}


function addClient(auth, p256dh, endpoint, Val) {

    var id = Val.split('-')[1];
    $.ajax({
        type: "POST",
        url: '/Subjects/AddClient',

        data: {
            "Id": id,
            "auth": auth,
            "endpoint": endpoint,
            "p256dh": p256dh
        },
        success: function (id) {


        },
        error: function () {

        }
    })
}

function arrayBufferToBase64(buffer) {
    var binary = '';
    var bytes = new Uint8Array(buffer);
    var len = bytes.byteLength;
    for (var i = 0; i < len; i++) {
        binary += String.fromCharCode(bytes[i]);
    }
    return window.btoa(binary);
}