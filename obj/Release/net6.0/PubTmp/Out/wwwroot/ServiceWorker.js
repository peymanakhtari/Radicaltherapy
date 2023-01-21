self.addEventListener('fetch', function (event) { });


self.addEventListener('push', function (e) {
    var body;
    
    if (e.data) {
        body = e.data.text().split("%")[0];
    } else {
        body = "Standard Message";
    }

    var options = {
        body: body,
        icon: "/img/alizare.png",
        vibrate: [100, 50, 100],
        data: {
            dateOfArrival: Date.now(), url: e.data.text().split("%")[1]
        },
        actions: [
            {
                action: "explore", title: "باز کردن",
                icon: "images/checkmark.png"
            },
            {
                action: "close", title: "بستن",
                icon: "images/red_x.png"
            },
        ]
    };
    e.waitUntil(
        self.registration.showNotification("پاسخ کامنت شما", options)
    );
});

self.addEventListener('notificationclick', function (e) {
    var notification = e.notification;
    var action = e.action;

    if (action === 'close') {
        notification.close();
    } else {
        // Some actions
        clients.openWindow(e.notification.data.url);
        notification.close();
    }
});


