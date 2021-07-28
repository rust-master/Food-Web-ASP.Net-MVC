(function ($) {
    "use strict";
    
    /*****************************
    * Commons Variables
    *****************************/
    var $window = $(window),
        $body = $('body');

     /**********************
     * Sticky Menu
     ***********************/
    $(window).on('scroll', function(event) {    
        var scroll = $(window).scrollTop();
        if (scroll < 350) {
            $(".sticky-header").removeClass("is-sticky");
        } else{
            $(".sticky-header").addClass("is-sticky");
        }
    });


    /*****************************
    * Off Canvas Function
    *****************************/
    (function () {
        var $offCanvasToggle = $('.offcanvas-toggle'),
            $offCanvas = $('.offcanvas'),
            $offCanvasOverlay = $('.offcanvas-overlay'),
            $mobileMenuToggle = $('.mobile-menu-toggle');
        $offCanvasToggle.on('click', function (e) {
            e.preventDefault();
            var $this = $(this),
                $target = $this.attr('href');
            $body.addClass('offcanvas-open');
            $($target).addClass('offcanvas-open');
            $offCanvasOverlay.fadeIn();
            if ($this.parent().hasClass('mobile-menu-toggle')) {
                $this.addClass('close');
            }
        });
        $('.offcanvas-close, .offcanvas-overlay').on('click', function (e) {
            e.preventDefault();
            $body.removeClass('offcanvas-open');
            $offCanvas.removeClass('offcanvas-open');
            $offCanvasOverlay.fadeOut();
            $mobileMenuToggle.find('a').removeClass('close');
        });
    })();


    /**************************
     * Offcanvas: Menu Content
     **************************/
    function mobileOffCanvasMenu() {
        var $offCanvasNav = $('.offcanvas-menu'),
            $offCanvasNavSubMenu = $offCanvasNav.find('.sub-menu');

        /*Add Toggle Button With Off Canvas Sub Menu*/
        $offCanvasNavSubMenu.parent().prepend('<div class="offcanvas__menu-expand"></div>');

        /*Category Sub Menu Toggle*/
        $offCanvasNav.on('click', 'li a, .offcanvas__menu-expand', function (e) {
            var $this = $(this);
            if ($this.attr('href') === '#' || $this.hasClass('offcanvas__menu-expand')) {
                e.preventDefault();
                if ($this.siblings('ul:visible').length) {
                    $this.parent('li').removeClass('active');
                    $this.siblings('ul').slideUp();
                    $this.parent('li').find('li').removeClass('active');
                    $this.parent('li').find('ul:visible').slideUp();
                } else {
                    $this.parent('li').addClass('active');
                    $this.closest('li').siblings('li').removeClass('active').find('li').removeClass('active');
                    $this.closest('li').siblings('li').find('ul:visible').slideUp();
                    $this.siblings('ul').slideDown();
                }
            }
        });
    }
    mobileOffCanvasMenu();


    /**********************
     * Vertical Menu
     ***********************/
    $('.header-menu-vertical .menu-title').on('click', function (event) {
      $('.header-menu-vertical .menu-content').slideToggle(500);
    });

    $('.menu-content').each(function () {
        var $ul = $(this),
            $lis = $ul.find('.menu-item:gt(4)'),
            isExpanded = $ul.hasClass('expanded');
        $lis[isExpanded ? 'show' : 'hide']();

        if ($lis.length > 0) {
            $ul
                .append($('<li class="expand">' + (isExpanded ? '<a href="javascript:;"><div><i class="icon-minus-square"></i>Close Categories</div></a>' : '<a href="javascript:;"><div><i class="icon-plus-square"></i>More Categories</div></a>') + '</li>')
                    .on('click', function (event) {
                        var isExpanded = $ul.hasClass('expanded');
                        event.preventDefault();
                        $(this).html(isExpanded ? '<a href="javascript:;"><div><i class="icon-plus-square"></i>More Categories</div></a>' : '<a href="javascript:;"><div><i class="icon-minus-square"></i>Close Categories</div></a>');
                        $ul.toggleClass('expanded');
                        $lis.toggle(300);
                    }));
        }
    });

    /***************************** 
    * Category more toggle  
    *****************************/

    $(".category-menu li.hidden").hide();
    $("#more-btn").on('click', function (e) {

        e.preventDefault();
        $(".category-menu li.hidden").toggle(500);
        var htmlAfter = '<i class="ion-ios-minus-empty" aria-hidden="true"></i> Less Categories';
        var htmlBefore = '<i class="ion-ios-plus-empty" aria-hidden="true"></i> More Categories';


        if ($(this).html() == htmlBefore) {
            $(this).html(htmlAfter);
        } else {
            $(this).html(htmlBefore);
        }
    });

    /******************************
     * Hero Slider - [Single Grid]
     *****************************/
        $('.hero').slick({
            arrows: true,
            fade: true,
            dots: true,
            easing: 'linear',
            speed: 2000,
            prevArrow: '<button type="button" class="hero-slider__arrow hero-slider__arrow--left"><i class="far fa-chevron-left"></i></button>',
            nextArrow: '<button type="button" class="hero-slider__arrow hero-slider__arrow--right"><i class="far fa-chevron-right"></i></button>',
            responsive: [

                {
                    breakpoint: 768,
                    settings: {
                        arrows: false,
                    }
                },
            ]
        });



    /************************************************
     * Product Slider - Style: Default [4 Grid, 2 Rows]
     ***********************************************/
    $('.product-default-slider-4grid-2rows').slick({
        arrows: true,
        slidesToShow: 4,
        infinite: false,
        rows: 2,
        slidesToScroll: 1,
        easing: 'ease-out',
        speed: 1000,
        prevArrow: '<button type="button" class="default-slider__arrow default-slider__arrow--left prevArrow"><i class="far fa-chevron-left"></i></i></button>',
        nextArrow: '<button type="button"  class="default-slider__arrow default-slider__arrow--right nextArrow"><i class="far fa-chevron-right"></i></button>',
        responsive: [

            {
                breakpoint: 1200,
                settings: {
                    slidesToShow: 3
                }
            },
            {
                breakpoint: 992,
                settings: {
                    slidesToShow: 2,
                }
            },
            {
                breakpoint: 575,
                settings: {
                    slidesToShow: 1,
                }
            },
        ]
    });

    /************************************************
     * Product Slider - Style: Default [4 Grid, 1 Rows]
     ***********************************************/
    $('.product-default-slider-4grid-1rows').slick({
        arrows: true,
        infinite: false,
        slidesToShow: 4,
        slidesToScroll: 1,
        rows: 1,
        easing: 'ease-out',
        speed: 1000,
        prevArrow: '<button type="button" class="default-slider__arrow default-slider__arrow--left prevArrow"><i class="far fa-chevron-left"></button>',
        nextArrow: '<button type="button"  class="default-slider__arrow default-slider__arrow--right nextArrow"><i class="far fa-chevron-right"></button>',
        responsive: [

            {
                breakpoint: 1200,
                settings: {
                    slidesToShow: 3
                }
            },
            {
                breakpoint: 992,
                settings: {
                    slidesToShow: 2,
                }
            },
            {
                breakpoint: 575,
                settings: {
                    slidesToShow: 1,
                }
            },
        ]
    });

    /************************************************
     * Testimonial Slider - Style:  [1 Grid, 1 Rows]
     ***********************************************/
    $('.testimonial__slider').slick({
        arrows: true,
        slidesToShow: 1,
        slidesToScroll: 1,
        easing: 'ease-out',
        speed: 1000,
        prevArrow: '<button type="button" class="default-slider__arrow default-slider__arrow--left prevArrow"><i class="far fa-chevron-left"></button>',
        nextArrow: '<button type="button"  class="default-slider__arrow default-slider__arrow--right nextArrow"><i class="far fa-chevron-right"></button>',
    });
        

    /************************************************
     * Blog Slider - Style: Feed [3 Grid, 1 Rows]
     ***********************************************/
    $('.blog-feed-slider-3grid').slick({
        slidesToShow: 3,
        slidesToScroll: 1,
        easing: 'linear',
        speed: 1000,
        prevArrow: '<button type="button" class="default-slider__arrow default-slider__arrow--left prevArrow"><i class="far fa-chevron-left"></button>',
        nextArrow: '<button type="button"  class="default-slider__arrow default-slider__arrow--right nextArrow"><i class="far fa-chevron-right"></button>',
        responsive: [

            {
                breakpoint: 1470,
                settings: {
                    slidesToShow: 3
                }
            },
            {
                breakpoint: 992,
                settings: {
                    slidesToShow: 2,
                }
            },
            {
                breakpoint: 768,
                settings: {
                    arrows: false,
                    slidesToShow: 2,
                    autoplay: true,
                }
            },
            {
                breakpoint: 480,
                settings: {
                    slidesToShow: 1,
                    arrows: false,
                    autoplay: true,
                }
            }
        ]
    });


    /************************************************
     * Company logo Slider
     ***********************************************/
    $('.company-logo__area').slick({
        arrows: true,
        infinite: true,
        slidesToShow: 6,
        slidesToScroll: 1,
        easing: 'linear',
        speed: 1000,
        prevArrow: '<button type="button" class="default-slider__arrow default-slider__arrow--left prevArrow"><i class="far fa-chevron-left"></button>',
        nextArrow: '<button type="button"  class="default-slider__arrow default-slider__arrow--right nextArrow"><i class="far fa-chevron-right"></button>',
        responsive: [
            {
                breakpoint: 1440,
                settings: {
                    slidesToShow: 6
                }
            },
            {
                breakpoint: 1200,
                settings: {
                    slidesToShow: 5
                }
            },
            {
                breakpoint: 992,
                settings: {
                    slidesToShow: 4
                }
            },
            {
                breakpoint: 768,
                settings: {
                    slidesToShow: 3
                }
            },
            {
                breakpoint: 480,
                settings: {
                    slidesToShow: 2
                }
            }
        ]
    });

    /***********************************
    * Gallery - Horizontal
    ************************************/
   $('.product-image--large-horizontal').slick({
        slidesToShow: 1,
        slidesToScroll: 1,
        arrows: false,
        fade: true,
    });
    $('.product-image--thumb-horizontal').slick({
        slidesToShow: 3,
        slidesToScroll: 1,
        focusOnSelect: true,
        prevArrow: '<button type="button" class="gallery__nav gallery__nav-horizontal gallery__nav-horizontal--left prevArrow"><i class="fas fa-chevron-left"></i></button>',
        nextArrow: '<button type="button"  class="gallery__nav gallery__nav-horizontal gallery__nav-horizontal--right nextArrow"><i class="fas fa-chevron-right"></i></button>'
    });
    /***********************************
    * Gallery - Vertical 
    ************************************/
   $('.product-image--large-vertical').slick({
        slidesToShow: 1,
        slidesToScroll: 1,
        arrows: false,
        fade: true,
    });
    $('.product-image--thumb-vertical').slick({
        slidesToShow: 3,
        slidesToScroll: 1,
        vertical: true,
        focusOnSelect: true,
        prevArrow: '<button type="button" class="gallery__nav gallery__nav-vertical gallery__nav-vertical--up prevArrow"><i class="fas fa-chevron-up"></i></button>',
        nextArrow: '<button type="button"  class="gallery__nav gallery__nav-vertical gallery__nav-vertical--down nextArrow"><i class="fas fa-chevron-down"></i></button>'
    });


    /***********************************
    * Gallery - Slider 
    ************************************/
   $('.product-gallery-box--single-slider').slick({
        slidesToShow: 3,
        slidesToScroll: 1,
        focusOnSelect: true,
        arrows: true,
        prevArrow: '<button type="button" class="gallery__nav gallery__nav-horizontal gallery__nav-horizontal--left prevArrow"><i class="fas fa-chevron-left"></i></button>',
        nextArrow: '<button type="button"  class="gallery__nav gallery__nav-horizontal gallery__nav-horizontal--right nextArrow"><i class="fas fa-chevron-right"></i></button>',
        responsive: [

            {
                breakpoint: 992,
                settings: {
                    slidesToShow: 3,
                }
            },
            {
                breakpoint: 768,
                settings: {
                    slidesToShow: 2,
                    arrows: false,
                    autoplay: true,
                    infinite: true,
                }
            },
            {
                breakpoint: 480,
                settings: {
                    slidesToShow: 1,
                    arrows: false,
                    autoplay: true,
                    infinite: true,
                }
            }
        ]
    });

    /***********************************
    * Blog Image Slider
    ************************************/
    $('.inner-slider-grid-1').slick({
        slidesToShow: 1,
        slidesToScroll: 1,
        focusOnSelect: true,
        arrows: true,
        prevArrow: '<button type="button" class="inner-slider__arrow inner-slider__arrow--left prevArrow"><i class="far fa-chevron-left"></i></button>',
        nextArrow: '<button type="button"  class="inner-slider__arrow inner-slider__arrow--right nextArrow"><i class="far fa-chevron-right"></i></button>',
    });

    /***********************************
    * Team Slider
    ************************************/
   $('.inner-slider-grid-4').slick({
        slidesToShow: 4,
        slidesToScroll: 1,
        focusOnSelect: true,
        arrows: true,
        prevArrow: '<button type="button" class="inner-slider__arrow inner-slider__arrow--left prevArrow"><i class="far fa-chevron-left"></i></button>',
        nextArrow: '<button type="button"  class="inner-slider__arrow inner-slider__arrow--right nextArrow"><i class="far fa-chevron-right"></i></button>',
        responsive: [

            {
                breakpoint: 992,
                settings: {
                    slidesToShow: 3,
                }
            },
            {
                breakpoint: 768,
                settings: {
                    slidesToShow: 2,
                }
            },
            {
                breakpoint: 576,
                settings: {
                    slidesToShow: 1,
                }
            }
        ]
    });

    /**********************
     * Price Range
     ***********************/
    $("#slider-range").slider({
      range: true,
      orientation: "horizontal",
      min: 0,
      max: 1000,
      values: [0, 1000],
      step: 100,
    
      slide: function (event, ui) {
        if (ui.values[0] == ui.values[1]) {
          return false;
        }
        
        $("#min_price").val(ui.values[0]);
        $("#max_price").val(ui.values[1]);
      }
    });


  /********************************
  *  Product Gallery - Image Zoom
  **********************************/
  $("#img-zoom").elevateZoom({
        gallery: "gallery-zoom",
        galleryActiveClass: "zoom-active",
        containLensZoom: true,
        zoomType: "inner",
        cursor: "crosshair"
    });


    /*******************
     * Video Popup
     *******************/
    $('.vinobox-popup').venobox();


    /*****************************
    *   Countdown
    **************************** */
    $('[data-countdown]').each(function () {
        var $this = $(this),
            finalDate = $(this).data('countdown');
        $this.countdown(finalDate, function (event) {
            $this.html(event.strftime('<div class="cdown day">%-D <p>Days</p></div> <div class="cdown hour">%-H <p>Hours</p></div> <div class="cdown minutes">%M <p>Mins</p></div> <div class="cdown second">%S <p>Sec</p></div>'));
        });
    });

    /*****************************
    * Create an account toggle
    *****************************/
    $(".creat-account").on("click", function () {
      $(".open-create-account").slideToggle(1000);
    });

    $(".shipping-account").on("click", function () {
      $(".open-shipping-account").slideToggle(1000);
    });


    /****************************
    * Password Hide/ Show Toggle
    *****************************/
    $(".password__toggle--btn").on("click", function() {

        $(this).toggleClass("fa-eye fa-eye-slash");
        var input = $($(this).attr("data-toggle"));
        if (input.attr("type") == "password") {
          input.attr("type", "text");
        } else {
          input.attr("type", "password");
        }
      });


    /****************************
    * Accordian - FAQ
    *****************************/
    const accordianItemHeaders = document.querySelectorAll(".accordian-item-header");

    accordianItemHeaders.forEach(accordianItemHeader => {
      accordianItemHeader.addEventListener("click", () => {
        const current = document.querySelector(".accordian-item-header.active");

        if (current && current !== accordianItemHeader) {
          current.classList.toggle("active");
          current.nextElementSibling.style.maxHeight = 0;
        }
        accordianItemHeader.classList.toggle("active");

        const accordianItemBody = accordianItemHeader.nextElementSibling;

        if (accordianItemHeader.classList.contains("active")) {
          accordianItemBody.style.maxHeight = accordianItemBody.scrollHeight + "px";
        } else {
          accordianItemBody.style.maxHeight = 0;
        }
      });
    });
    

    /****************************
    * Google Map - Location
    *****************************/
   function init() {
    var mapOptions = {
        zoom: 11,
        scrollwheel: false,
        center: new google.maps.LatLng(40.709896, -73.995481),
    };
    var mapElement = document.getElementById('map');
    var map = new google.maps.Map(mapElement, mapOptions);
    var marker = new google.maps.Marker({
        position: new google.maps.LatLng(40.709896, -73.995481),
        map: map,
        icon: 'assets/img/icon/map-point.png',
        animation:google.maps.Animation.BOUNCE,
        title: 'Snazzy!'
    });
    }
    google.maps.event.addDomListener(window, 'load', init);



    /*----------------------------------
        Scroll To Top Active
    -----------------------------------*/
    $('body').materialScrollTop();

})(jQuery);
