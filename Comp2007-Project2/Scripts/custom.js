/**
* Authors : Emma Hilborn (200282755),
            Alex Friesen (200302342),
            Dan Masci (200299037),
            Karen Springford(200299681)
* Class : Enterprise Computing
* Semester : 4
* Professor : Tom Tsiliopolous
* Purpose : Final Team Project - E-Commerce Store
* Website Name : ezgames.azurewebsites.net
*/

/**
* The following file is the "MASTER" Javascript file that encompasses JQuery. It includes
* our Landing Page Rotator and any other custom jQuery functionality that is used across 
* our application.
*/

jQuery(document).ready(function ($) {

    /*************************************************
	*					MOBILE MENU
	*************************************************/
    $('nav#header-nav').moby({
        mobyTrigger: $('#moby-button'), // Button that will trigger the Moby menu to open
    });
    
    /*************************************************
	*       		   SHOPPING CART 
	*************************************************/
    /***********************
    *       DELETE
    ***********************/
    $(".DeleteLink").click(function () {
        var gameToDelete = $(this).attr("data-id");
        console.log(gameToDelete);
        if (gameToDelete != '') {
            // Perform the ajax post
            $.post("/ShoppingCart/DeleteFromCart/" + gameToDelete,
                function (data) {
                    // Successful requests get here
                    // Update the page elements
                    $('#item-' + data.DeleteId).fadeOut('slow'); //Remove Item from frontend
                    //Update Numeric Amounts
                    updatePage(data);
                });
        }
    });
    /***********************
    *       REMOVE
    ***********************/
    $(".RemoveLink").click(function () {
        // Get the id from the link
        var recordToDelete = $(this).attr("data-id");
        if (recordToDelete != '') {
            // Perform the ajax post
            $.post("/ShoppingCart/RemoveFromCart/" + recordToDelete,
                function (data) {
                    // Successful requests get here
                    // Update the page elements
                    if (data.ItemCount == 0) {
                        $('#item-' + data.DeleteId).fadeOut('slow'); //Remove Item from frontend
                    } else {
                        $('#count-' + data.DeleteId).text(data.ItemCount); //Update frontend Item Count
                    }
                    //Update Numeric Amounts
                    updatePage(data);
                });
        }
    });
    /***********************
    *         ADD
    ***********************/
    $('.AddLink').click(function () {
        // Get the id from the link
        var gameToAdd = $(this).attr('data-id');
        if (gameToAdd != '') {
            // Perform the ajax post
            $.post('/ShoppingCart/AddToCart/' + gameToAdd,
                function (data) {
                    // Successful requests get here
                    //Update the page elements
                    $('.count-' + data.AddId).text(data.ItemCount); //Update frontend Item Count
                    //Update Numeric Amounts
                    updatePage(data);
                });
            console.log($(this));
            console.log(this);
            if ($(this).hasClass('href')) {
                window.location.href = "/ShoppingCart";
            }
        }
    });
    function updatePage(data) {
        $('.subtotal').text((data.CartTotal).toFixed(2));
        $('.tax').text((data.CartTotal * 0.15).toFixed(2));
        $('.total').text((data.CartTotal * 1.15).toFixed(2));
        $('#update-message').html(data.Message);
    };
    /***********************
    * PRODUCT CATALOG PAGE
    ***********************/
    if ($('#store-page').length > 0) {
        $('.AddLink').click(function () {
            var target = $(this).parent().find('.quantity');
            var count = target.text();
            target.text(++count);
            target.addClass("active");
        });
    }

    /*************************************************
	*					ROTATOR
	*************************************************/
    if ($('.rotator').length > 0) {
        //Determine necessary variables
        var numOfSlides = $('.slide').length;
        var slideNum = 1;
        var changed = false;
        var controlID;
        var slideID;

        /**
		*	Generate Rotator Controls
		*/
        for (var x = 1; x <= numOfSlides; x++) {
            $('.rotator-controls').append('<div class="control" id="control' + x + '"></div>');
        }
        $('#control1').addClass('active');

        /**
		*	Previous and Next Functions, appropriately
		*/
        function prevSlide(e) {
            //Create an image of Infinite Loop
            if (slideNum > 1) {
                slideNum--;
                //Make appropriate Class changes - change behaviour with CSS/Less				
                $('.slide').removeClass('active');
                $('#slide' + slideNum).addClass('active');
                $('.control').removeClass('active');
                $('#control' + slideNum).addClass('active');
            }
            else {
                slideNum = numOfSlides;
                //Make appropriate Class changes - change behaviour with CSS/Less				
                $('.slide').removeClass('active');
                $('#slide' + slideNum).addClass('active');
                $('.control').removeClass('active');
                $('#control' + slideNum).addClass('active');
            }
            changed = true;
        }//prevSlide
        function nextSlide(e) {
            //Create an image of Infinite Loop
            if (slideNum < numOfSlides) {
                slideNum++;
                //Make appropriate Class changes - change behaviour with CSS/Less
                $('.slide').removeClass('active');
                $('#slide' + slideNum).addClass('active');
                $('.control').removeClass('active');
                $('#control' + slideNum).addClass('active');
            }
            else {
                slideNum = 1;
                //Make appropriate Class changes - change behaviour with CSS/Less
                $('.slide').removeClass('active');
                $('#slide' + slideNum).addClass('active');
                $('.control').removeClass('active');
                $('#control' + slideNum).addClass('active');
            }
            changed = true;
        }
        function changeSlide(e) {
            //Grab ID of clicked-upon control 
            controlID = $(this).attr('id');
            slideID = controlID.split('control');
            slideNum = slideID[1];

            //Remove active from all and then give to appropriate slide
            $('.slide').removeClass('active');
            $('#slide' + slideNum).addClass('active');

            //Remove active from all and then give to appropriate control 
            $('.control').removeClass('active');
            $('#' + controlID).addClass('active');
            changed = true;
        }//changeSlide

        //Call the appropriate functions
        $('.rotator-arrows .prev').on('click', prevSlide);
        $('.rotator-arrows .next').on('click', nextSlide);
        $('.rotator-controls .control').on('click', changeSlide);

        setInterval(function () {
            //If the slide has NOT been manually changed in the last 7 seconds: change the slide.
            if (!changed) {
                slideID = $('.slides').find('.active').attr('id');
                slideNum = slideID.split('slide')[1];

                if (slideNum < numOfSlides) {
                    slideNum++;
                }
                else {
                    slideNum = 1;
                }
                //Remove active from all and then give to appropriate slide
                $('.slide').removeClass('active');
                $('#slide' + slideNum).addClass('active');

                //Remove active from all and then give to appropriate control 
                $('.control').removeClass('active');
                $('#control' + slideNum).addClass('active');
            }
                //else if the slide HAS been manually changed in the last 7 seconds; 'reset' the timer.
            else {
                changed = false;
            }
        }, 7000);
    }//ROTATOR
    
    /*************************************************
	*             FORM VALIDATOR MESSAGES
	*************************************************/
    //Allow user to close a Validator Error Message by clicking on it - Forms(Register/Login)
    $('.input-container .message').click(function () {
        $(this).css('visibility', 'hidden');
    });
    $('.submit.button input').click(function () {
        $('.input-container .message').css('visibility', 'visible');
    });

});