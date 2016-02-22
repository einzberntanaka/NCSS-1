/*
 *
 *  SPCP
 *  Copyright 2014. All rights reserved.
 *
 *
 */
(function () {
  'use strict';

  // handle every submit button (must have a atribute data-form with the ID of the form to submit)
  $('.wt-submit').on ('click', function(e){
    e.preventDefault();
    var $form = $( "#" + $(this).attr('data-form') );
    if ($form.length > 0) {
      $form.submit();
    }
  });

  if ($.fn.tooltip) {
		$('.tip').tooltip();// any tooltip
	}

  if ($.fn.popover) {
	  $('[data-toggle="popover"], .pop').popover({html:true}).click(function(e) {
		    e.preventDefault();
		});
	  // cancel a popover on body click
	  $('body').on('click', function (e) {
	    $('[data-toggle="popover"], .pop').each(function () {
	        //the 'is' for buttons that trigger popups
	        //the 'has' for icons within a button that triggers a popup
	        if (!$(this).is(e.target) && $(this).has(e.target).length === 0 && $('.popover').has(e.target).length === 0) {
	            $(this).popover('hide');
	        }
	    });
	  });
	}

  // notificatin close
  $('.notification .notification__close').click(function(){
    $(this).parent().slideUp(1000);
  });

  // back to top
    $("#toTop").click(function (e) {
      e.preventDefault();
     $("html, body").animate({scrollTop: 0}, 1000);
  });

  // IF RESPONSIVE PAGE ONLY
  if ( $.isFunction($.fn.sidr) ) {
     // sidr menu
      $('#responsive-menu').sidr({
        name: 'sidr-main',
        source: '.page-header--menu .nav'
      });

      // $(window).touchwipe({
      //   wipeLeft: function() {
      //     // Close
      //     $.sidr('close', 'sidr-main');
      //   },
      //   wipeRight: function() {
      //     // Open
      //     $.sidr('open', 'sidr-main');
      //   },
      //   preventDefaultEvents: false
      // });
    }

  // correct placeholder in browsers that do not support them (IE9 and below)
  $('input').placeholder();

  // normal and big size buttons
    $("#font-normal").click(function (e) {
      e.preventDefault();
      //$("body").css("font-size", "14px");
    });

    $("#font-big").click(function (e) {
      e.preventDefault();
      //$("body").css("font-size", "16px");
    });

    $("#font-small").click(function (e) {
      e.preventDefault();
      //$("body").css("font-size", "16px");
    });

    // navigation
    $('.sidr-inner > ul > li > a:not(.sidr-class-logout):not(.sidr-class-home-link)').click(function (e) {
      e.preventDefault();
    });

    $('.content-navigation .more').click(function(e) {
      e.preventDefault();
      $(this).parent().toggleClass('open');
    });

    // mobile search form
    $('#mobile-search a').click(function(e) {

      e.preventDefault();
      $('#mobile-search-form').slideToggle();
    });

    // user info dropdown
    $('.user-info').hover(function(e) {
      e.preventDefault();
      $(this).find('.details').toggle();
    });

    // .withsidemenu__sidemenu
    $('.withsidemenu__sidemenu .nav > ul > li.has-sub-menu > a').on('click', function(e) {
      e.preventDefault();
      $(this).parent().toggleClass('open');
      $(this).parent().find('.sub-menu').slideToggle();
    });

    // homepage post login
    $('.homepage__postlogin a').hover(
      function() {
          $(this).find('img').attr('src', $(this).find('img').attr('src').replace(/\.png/, '-on.png') );
      },
      function() {
          $(this).find('img').attr('src', $(this).find('img').attr('src').replace('-on.png', ".png") );
      }
      );

})();