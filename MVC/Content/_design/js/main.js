/*******************************************************************************

	Title:  Pizza Hut Delivery
	Date:   December 2012
	Author: Suitmedia (http://www.suitmedia.com)

********************************************************************************/

var Site = {

	/**
	 * Init Function
	 */
	init: function() {
		$('html').removeClass('no-js');
		
		Site.popupOrder();
		Site.movingBoxMenu();
		Site.sliderHotPromo();
		Site.showChosenMenu();
		$('input[type="radio"].radio-pizza-regular').click(Site.disableSplitza);
		$('.menu-slide-list input[type="radio"]').click(Site.onClickScrollTo);
		$('.price-group li.menu-list').hover(Site.hoverSocialMedia);

		Site.customSelect();
		Site.sliderHot();
    	Site.sliderMenuContent();
    	Site.editForm();
    	Site.paddictDatePicker();
        Site.DateTime();
         $('#landing').trigger('click');
         $('#registered').trigger('click');
         check = document.getElementById("target");
         if(check != null)
         {
         $("html, body").animate({ scrollTop: $('#target').offset().top }, 1000);
         }
    	//$('a.fancybox-valentine').trigger("click");

    	/*Site.wordLimit();*/
    	
	},
	
	/**
	 * Slider Hot
	 */
	sliderHot: function() {
		$('.slider-hot-content').cycle({
			 fx:  'scrollRight',
			 speed: 'fast',
			 pager: '.slider-hot-nav',
			 cleartypeNoBg: true
		});
	},

	/**
	 * Hot Promo
	 */
	sliderHotPromo: function() {
		$('.hot-promo-container .slide-container ul').cycle({
			fx:  'scrollHorz',
			 speed: 'fast',
			 pager:  '.hot-promo-container .slider-nav-container .slider-nav',
			 prev:   '.hot-promo-container .slide-container .slide-arrows .left',
			 next:   '.hot-promo-container .slide-container .slide-arrows .right',
			 timeout: 0,
			 cleartypeNoBg: true

		});
	},

	/**
	 * Common-slide
	 */
	sliderHotPromo: function() {
		$('.slide-container ul').cycle({
			fx:  'scrollHorz',
			 speed: 'fast',
			 pager:  '.slider-nav-container .slider-nav',
			 prev:   '.slide-container .slide-arrows .left',
			 next:   '.slide-container .slide-arrows .right',
			 timeout: 0,
			 cleartypeNoBg: true

		});
	},

    /**
    * Show social media span when hovered
    */

    hoverSocialMedia: function () {
        $(this).children('span').fadeToggle("medium", "swing");
    },

    /**
    * Autoscrolling when choosing menu
    */
    onClickScrollTo: function () {

    /*    var id = $(this).attr('href');

        console.log(id);

        if ($(this).is(':checked')) {
            $("html, body").animate({ scrollTop: $("#" + id).offset().top }, 1000);
        }

        */

    },

	/**
	 * Menu Moving Boxes
	 */
	movingBoxMenu: function() {
		$('.menu-slide .slide').movingBoxes({
		width:610,
		startPanel: 1,
		reducedSize: 0.6,
		fixedHeight: true,
		initAnimation: true,
		stopAnimation: false,
		hashTags: false,
		wrap: true,
		buildNav: false,
		navFormatter: function(index, panel) {
	        return "&#9679;" // bullets
	    },
	    easing: 'swing',
	    speed: 500,
	    delayBeforeAnimate: 0,
	    currentPanel: 'current',
	    tooltipClass: 'tooltip',
	    disabled: 'disabled'
		});
	},

	/**
	 * Show chosen menu
	 */

	showChosenMenu: function() {
		$('.nav-choice li a').click(function() {
			var link = $(this).attr('href');
			console.log(link);
			$('.menu-slide-list > li.chosen').addClass("hidden");
			$('.menu-slide-list > li.chosen').removeClass("chosen");
			$('.menu-slide-list > li'+ link).removeClass("hidden");

			$('.menu-slide-list > li'+ link).addClass("chosen");
			$('.menu-slide-list > li'+ link + ' .slide').css('width','610px !important');
			$('.menu-slide-list > li'+ link + ' .slide').movingBoxes({
				width:610,
				startPanel: 1,
				reducedSize: 0.6,
				fixedHeight: true,
				initAnimation: true,
				stopAnimation: false,
				hashTags: false,
				wrap: true,
				buildNav: false,
				navFormatter: function(index, panel) {
			        return "&#9679;" // bullets
			    },
			    easing: 'swing',
			    speed: 500,
			    delayBeforeAnimate: 0,
			    currentPanel: 'current',
			    tooltipClass: 'tooltip',
			    disabled: 'disabled'
			});
		});       
	},
    
	/**
	 * Wordlimiter
	 */
	wordLimit: function() {
		console.log('text');
    	var limit = 1000;
    	var charCount = $(".survey .textinput").val().length;

    	if(charCount > limit || charCount == 0) {
	   		$(".button-container input[type='submit']").attr('disabled', 'disabled');
	   		if (charCount > limit) {
	   			$(".survey .notification").css('color','red');
	   		}
	   		
	   }

    	$(".survey .textinput").bind('input propertychange', function() {
		   charCount = this.value.length;
		   $(".survey .notification").html((limit-charCount) + " karakter");
		   if(charCount > limit  || charCount == 0) {
		   		$(".button-container input[type='submit']").attr('disabled', 'disabled');
		   		if (charCount > limit) {
		   			$(".survey .notification").css('color','red');
		   		}
		   } else if (charCount <= limit) {
		   		$(".button-container input[type='submit']").removeAttr('disabled');
		   		$(".survey .notification").css('color','#603913');
		   }
		});
    	/*$(".survey textarea").change(function() {
    		var charCount = $(this).html().length;
    		alert(charCount);
    		$(".survey .notification").html((limit-2) + " karakter");
    	});*/
	},

//tambahan datepicker
    DateTime: function() {
        $('#Date').datepicker({
            showTime: true,
            constrainInput: false,
            dateFormat: "myd"
         });

/*         $('#Time').timepicker({ 'timeFormat': 'H:i','minTime': '9:00am',
	'maxTime': '2:00am', 'step': 15 });
 */   },

	/**
   * Datepicker
   */ 
	paddictDatePicker: function() { 
		$('.p-addict #birthdate').datepicker();
	},

	/**
	* Script for p-addict edit form
	*/ 
	editForm: function() { 
		$('.p-addict .login .edit a').click(function() {
			

			$(this).parent().next("form").animate({
				height : 'toggle'
			});



			return false;
		});

		$('.p-addict .address-list > .edit a').click(function() {
			

			$(".p-addict .address-list .address-add form").animate({
				height : 'toggle'
			});



			return false;
		});

		$('.p-addict .user-data li .edit a').click(function() {

			
			$(this).parent().next().next("form").animate({
				height : 'toggle'
			});



			return false;
		});

		$('.p-addict .user-favorite .edit a').click(function() {
			

			$(".p-addict .user-favorite input[type='text']").animate({
				height : 'toggle'
			});

			$(".p-addict .user-favorite .button-container").animate({
				height : 'toggle'
			});



			return false;
		});

		$('.p-addict input[value="cancel"]').click(function() {
			if($(this).parent().parent("form").parent().attr("class")=="user-favorite") {
				$(".p-addict .user-favorite input[type='text']").animate({
					height : 'toggle'
				});

				$(".p-addict .user-favorite .button-container").animate({
					height : 'toggle'
				});
			} else {
				$(this).parent().parent("form").animate({
					height : 'toggle'
				});
			}
			
		});
		
	},
	
	/**
	 * Popup Order
	 */
	popupOrder: function() {

	 $(".fancybox-menuimage").fancybox({
    		closeBtn : false,
    		hideOnContentClick : false
    });

    $(".fancybox-order").fancybox({
    		closeBtn : false,
        padding  : 0
    });

    $(".fancybox-area").fancybox({
    		closeBtn : false,
            inline: true
    });

    /*$(".fancybox-area").colorbox({
		inline: true
	});*/

    $(".fancybox-congrats").fancybox({
    		closeBtn : false,
    		hideOnContentClick : false

    });

    $(".fancybox-valentine").fancybox({
    		closeBtn : false,
		hideOnContentClick : false
    });

    $(".fancybox-register").fancybox({
    		closeBtn : false,
    		hideOnContentClick : false

    });

    $(".fancybox-notif").fancybox({
    	closeBtn : false,
    	closeClick : true
    });

	/*$(".popup-valentine .wrapper").dialog({
	     height:500,
	     width:900,
	      modal: true
	    });*/
	  

/*$('a.uimodal-ajax').click(function() {
            var url = this.href;
            // show a spinner or something via css
            var dialog = $('<div style="display:none" class="loading"></div>').appendTo('body');
            // open the dialog
            dialog.dialog({
                // add a close listener to prevent adding multiple divs to the document
                close: function(event, ui) {
                    // remove div with all data and events
                    dialog.remove();
                },
                modal: true
            });
            // load remote content
            dialog.load(
                url, 
                {}, // omit this param object to issue a GET request instead a POST request, otherwise you may provide post parameters within the object
                function (responseText, textStatus, XMLHttpRequest) {
                    // remove the loading class
                    dialog.removeClass('loading');
                }
            );
            //prevent the browser to follow the link
            return false;
        });
    });*/

    var fancy_deliver = $(".fancybox-delivery").fancybox({
    		closeBtn : false,
    		hideOnContentClick : false
    	});

	},

  /**
   * Custom Select
   */ 
  customSelect: function() { 
    $('#custom-select').msDropDown({mainCSS:'dd2'}).data();

     /*$(".chzn-select").chosen();*/

  },

  disableSplitza: function() { 
    

    if ($(this).is(':checked')) {
    		//alert("tes");
    		$('input[type="radio"].splitza').attr("disabled", "true");
    	} else if (!$(this).is(':checked')) {
    		$('input[type="radio"].splitza').removeAttr("disabled");
    	}


  },

  /**
   * Check Area autocomplete
   */ 
  checkAreaAuto: function() { 
    

	var availableTags = [
	            "ActionScript",
	            "AppleScript",
	            "Asp",
	            "BASIC",
	            "C",
	            "C++",
	            "Clojure",
	            "COBOL",
	            "ColdFusion",
	            "Erlang",
	            "Fortran",
	            "Groovy",
	            "Haskell",
	            "Java",
	            "JavaScript",
	            "Lisp",
	            "Perl",
	            "PHP",
	            "Python",
	            "Ruby",
	            "Scala",
	            "Scheme"
	        ];

    $( ".form-check-area .auto" ).autocomplete({
        source: availableTags,
        position: {my : "left bottom", at:"left top"}
        /*change: function (event, ui) {
            //if the value of the textbox does not match a suggestion, clear its value
            if ($(".ui-autocomplete li:textEquals('" + $(this).val() + "')").size() == 0) {
                $(this).val('');
            }
        }*/
    }).live('keydown', function (e) {
        var keyCode = e.keyCode || e.which;
        //if TAB or RETURN is pressed and the text in the textbox does not match a suggestion, set the value of the textbox to the text of the first suggestion
        if((keyCode == 9 || keyCode == 13) && ($(".ui-autocomplete li:textEquals('" + $(this).val() + "')").size() == 0)) {
            $(this).val($(".ui-autocomplete li:visible:first").text());
        }
    });

    /*$(".chzn-select").chosen();*/

  },

  /**
   * Slider Menu Content
   */ 
  sliderMenuContent: function() { 
    $('.slider-menu-content ul').cycle({
       fx:  'scrollRight',
       speed: 'fast',
       prev: '.slider-menu-content-prev',
       next: '.slider-menu-content-next',
       pager: '.slider-menu-content-nav',
       cleartypeNoBg: true
    });
  },

  

  /**
   * Google maps
   */ 
    initializeGoogleMaps: function(lat,lang,map_canvas) {
	var myLatlng = new google.maps.LatLng(lat,lang);
	var mapOptions = {
		zoom: 17,
		center: myLatlng,
		mapTypeId: google.maps.MapTypeId.ROADMAP
	}
 
	var map = new google.maps.Map(document.getElementById(map_canvas), mapOptions);

	var image = '/Content/_design/images/img-area-pin.png';
	var myLatLng = new google.maps.LatLng(lat,lang);
	var beachMarker = new google.maps.Marker({
		position: myLatLng,
		map: map,
		icon: image
		});
	}



}

$(document).ready(function() {
	Site.init();
    /*
        this script is used for replacing anchor #target in url
    */
    
	(function (d, s, id) {
	    var js, fjs = d.getElementsByTagName(s)[0];
	    if (d.getElementById(id)) return;
	    js = d.createElement(s); js.id = id;
	    js.src = "//connect.facebook.net/en_US/all.js#xfbml=1";
	    fjs.parentNode.insertBefore(js, fjs);
	} (document, 'script', 'facebook-jssdk'));

	!function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0]; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = "//platform.twitter.com/widgets.js"; fjs.parentNode.insertBefore(js, fjs); } } (document, "script", "twitter-wjs");
    
    if($('#target').length){
        $('html, body').animate({
            scrollTop: $('#target').offset().top
        }, 'slow', 'swing'); 
    }
});



