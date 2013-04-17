<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>RegisterOk</title>
</head>
<script src="http://code.jquery.com/jquery-1.7.1.min.js"  ></script>

<script type="text/javascript">
    function init() {
        timer.init(0, 5, 0);
    }
    var timer = {
        minutes: 0,
        seconds: 0,
        elm: null,
        samay: null,
        sep: ':',
        init: function (h, m, s) {
            h = parseInt(h, 10);
            m = parseInt(m, 10);
            s = parseInt(s, 10);
            if (h < 0 || m < 0 || s < 0 || isNaN(h) || isNaN(m) || isNaN(s)) { alert('Invalid Values'); return; }
            this.hours = h;
            this.minutes = m;
            this.seconds = s;
            timer.start();
        },
        start: function () {
            this.samay = setInterval((this.doCountDown), 1000);
        },
        doCountDown: function () {
            if (timer.seconds == 0) {
                if (timer.minutes == 0) {
                    if (timer.hours == 0) {
                        clearInterval(timer.samay);
                        timerComplete();
                        return;
                    }
                    else {
                        timer.seconds = 60;
                        timer.minutes = 59;
                        timer.hours--;
                    }
                }
                else {
                    timer.seconds = 60;
                    timer.minutes--;
                }
            }
            timer.seconds--;
            timer.updateTimer(timer.hours, timer.minutes, timer.seconds);
        },
        updateTimer: function (hr, min, secs) {
            hr = (hr < 10 ? '0' + hr : hr);
            min = (min < 10 ? '0' + min : min);
            secs = (secs < 10 ? '0' + secs : secs);
            if (hr <= 0 && min <= 0 && secs <= 0) {
                document.getElementById('minutes').style.display = "none";
                document.getElementById('seconds').style.display = "none";
                return;
            }
            else {
                document.getElementById('minutes').innerHTML = min;
                document.getElementById('seconds').innerHTML = secs;
            }
        }
    }
    function timerComplete() {
        $('#awal').hide();
        $('#akhir').show();
    }
</script>
<body>
    <div id='awal'> 
      <div  class="popup-order">
      <p class="popup-count">
        <img src="<%:Url.Content("~/Content/_design/images/txt-order-1.png") %>">
      </p>
      <div class="countdown">
        <h2><span id="hours"></span><span id="minutes"></span>:<span id="seconds"></h2>
  	    <p>waktu tersisa</p>
      </div>
      </div>
    </div>
    <div id="akhir" style="display:none">
     <div  class="popup-order">
        <p class="popup-count">
        <img src="<%:Url.Content("~/Content/_design/images/txt-order-2.png") %>">
        </p>
      <div class="countdown">
        <h2>00:00</h2>
  	    waktu habis
      </div>
      </div>
    </div>
    <div id="success" style="display:none">
    <div class="splashpopup" >
     <img src="<%:Url.Content("~/Content/_design/images/img-popup-splash.jpg") %>">
    </div>
    </div>
    <script type="text/javascript">
        init();
    </script>
</body>
</html>
