// Initialize slider
$(function () {
    jQuery('.tp-banner').revolution({
        sliderType: "hero",
        sliderLayout: "fullscreen",
        dottedOverlay: "none",
        delay: 9000,
        navigation: {
        },
        responsiveLevels: [1240, 1024, 778, 480],
        visibilityLevels: [1240, 1024, 778, 480],
        gridwidth: [1240, 1024, 778, 480],
        gridheight: [868, 768, 960, 720],
        lazyType: "none",
        parallax: {
            type: "mouse",
            origo: "slidercenter",
            speed: 400,
            levels: [1, 2, 3, 4, 5, 10, 15, 20, 25, 46, 47, 48, 49, 50, 51, 55],
        },
        shadow: 0,
        spinner: "off",
        autoHeight: "off",
        fullScreenAutoWidth: "off",
        fullScreenAlignForce: "off",
        fullScreenOffsetContainer: "",
        fullScreenOffset: "",
        disableProgressBar: "on",
        hideThumbsOnMobile: "off",
        hideSliderAtLimit: 0,
        hideCaptionAtLimit: 0,
        hideAllCaptionAtLilmit: 0,
        debugMode: false,
        fallbacks: {
            simplifyAll: "off",
            disableFocusListener: false
        }
    });  
});

// Initialize particles for slider
$(function() {
    particlesJS.load('particles-js', '../../Scripts/External/particles/particles-config.json', function () {
        console.log('callback - particles.js config loaded');
    });
});

$(function() {
    $('.portfolio-list')
        .isotope({
            itemSelector: '.portfolio-item',
            percentPosition: true,
            masonry: {
                columnWidth: '.portfolio-item-sizer'
            },
            containerStyle: {
                position: 'relative',
                overflow: 'hidden'
            }
        });
});