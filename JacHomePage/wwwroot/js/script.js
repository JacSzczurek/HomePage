    /* DODAJE KLASE STICKY */
$(document).ready(function () {

    $('.js--section-about').waypoint(function(direction){
        if (direction == "down") {
            $('nav').addClass('sticky');
        } else {
            $('nav').removeClass('sticky');
        }
    }, {
       offset: '60px;'
    });                          
    
    /* SCROLL NA BUTTONACH*/
    
    $('.js--scroll-to-about').click(function () {
       $('html, body').animate({scrollTop: $('.js--section-about').offset().top}, 1000); /* SELECT, ANIMACJA DO TEGO ELEMENTU (do jego TOPa), W CZASIE 1000 ms */
    });
    $('.js--scroll-to-contact').click(function () {
       $('html, body').animate({scrollTop: $('.js--section-contact').offset().top}, 1000); /* SELECT, ANIMACJA DO TEGO ELEMENTU (do jego TOPa), W CZASIE 1000 ms */
    });
    
    
    /****  SMOOTH SCROLLING   ***********/
    
    $('a[href*="#"]')
  // Remove links that don't actually link to anything
  .not('[href="#"]')
  .not('[href="#0"]')
  .click(function(event) {
    // On-page links
    if (
      location.pathname.replace(/^\//, '') == this.pathname.replace(/^\//, '') 
      && 
      location.hostname == this.hostname
    ) {
      // Figure out element to scroll to
      var target = $(this.hash);
      target = target.length ? target : $('[name=' + this.hash.slice(1) + ']');
      // Does a scroll target exist?
      if (target.length) {
        // Only prevent default if animation is actually gonna happen
        event.preventDefault();
        $('html, body').animate({
          scrollTop: target.offset().top
        }, 1000, function() {
          // Callback after animation
          // Must change focus!
          var $target = $(target);
          $target.focus();
          if ($target.is(":focus")) { // Checking if the target was focused
            return false;
          } else {
            $target.attr('tabindex','-1'); // Adding tabindex for elements not focusable
            $target.focus(); // Set focus again
          };
        });
      }
    }
  });
    
    /******   ANIMATE ON SCROLL   *****////
    
    $('.js--animation-wp-1').waypoint(function (direction) {
        $('.js--animation-wp-1').addClass('animated bounce');
    }, {
        offset : '50%'
    });
    
    $('.js--animation-wp-2').waypoint(function (direction) {
        $('.js--animation-wp-2').addClass('animated fadeInUp');
    }, {
        offset : '50%'
    })
    
    $('.js--animation-wp-3').waypoint(function (direction) {
        $('.js--animation-wp-3').addClass('animated fadeIn');
    }, {
        offset : '50%'
    })
    
    $('.js--animation-wp-4').waypoint(function (direction) {
        $('.js--animation-wp-4').addClass('animated pulse');
    }, {
        offset : '50%'
    })
    
    /**** MOBILE NAV ***/
    
    $('.js--nav-icon').click(function () {
        var nav =  $('.js--main-nav');
        var icon = $('.js--nav-icon i');
        
        nav.slideToggle(200);            /* TOGGLE 200 MS */
        
        //if (icon.hasClass('ion-navicon-round')) {                 
        //    icon.addClass('ion-close-round');
        //    icon.removeClass('ion-navicon-round');
        //} else {
        //    icon.addClass('ion-navicon-round');
        //    icon.removeClass('ion-close-round');
        //}

        
    });
    
    
    
    
    
});