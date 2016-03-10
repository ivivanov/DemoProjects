// ==UserScript==
// @name         Point alert
// @namespace    http://tampermonkey.net/
// @version      0.1
// @description  try to take over the world!
// @author       You
// @match        https://mobile.bet365.com
// @grant        none
// ==/UserScript==
/* jshint -W097 */

HC_POINTS = -100;

(function () {

    'use strict';

    document.addEventListener('DOMContentLoaded', function () {
        if (Notification.permission !== "granted")
            Notification.requestPermission();
    });

    function notifyMe(msg) {
        if (!Notification) {
            alert('Desktop notifications not available in your browser. Try Chromium.');
            return;
        }

        if (Notification.permission !== "granted")
            Notification.requestPermission();
        else {
            var notification = new Notification(
                'Criteria reached', {
                body: msg,
            });

            notification.onclick = function () {
                //window.open("http://stackoverflow.com/a/13328397/1269037");
            };

        }

    }

    console.log("notify me init");
    notifyMe("notifyMe inited")

    var notificationCounter = 0;

    setInterval(checkOdd, 1000);

    function checkOdd() {
        console.log("script point alert is running");

        var str = document.getElementsByClassName("hdCapDisplay")[0].textContent;
        if (str) {
            var point = parseFloat(str);
            console.log(point + "  HC_POINTS   " + HC_POINTS);
            if (point >= HC_POINTS) {
                console.log("bet!")
                if (notificationCounter < 3) {
                    notifyMe("bet now");
                    notificationCounter++;
                }
            }
        }
    }
})();
