$( document ).ready(function() {
	
	//uat 293
	var searchButtonClicked = false;
	//-----------------------------
	
	/*$("nav ul li").click(function(){
   
    $("nav ul li").removeClass("active");
    	$(this).addClass("active");
    	$(this).addClass("active");
	});*/

	 $('ul.sub-menu > li').each(function(){
	        var path = window.location.href;	        
	        var current = path.substring(path.lastIndexOf('/')+1);
	        var stripIndex = path.lastIndexOf('?');
	        var current ="";
	        var len = path.length;
	        if(stripIndex!=-1){
	        	len = stripIndex;	
	        }
	        current = path.substring(path.lastIndexOf('/')+1, len);  
	        //$("a", this).hide();
	        //var url = $("a", this).attr('href');
	        //var ref = url.substring(url.lastIndexOf('/')+1);
	        if(current == 'registerinstructions' || current == 'registerpage' || current == 'registerstep2' || current == 'registercomplete'){
	        	 $('#registerMenu').addClass('active');
	        	 $('#sidr-id-registerMenu').addClass('highlight');
		         $('#servicesMenu').addClass('active');
		         $('#sidr-id-servicesMenu').addClass('sidr-class-active');
		         return false;
	        }
	        if(current == 'chkAppStatuspage' || current == 'checkAppStatusSubmit'){
	        	 $('#checkAppStatusMenu').addClass('active');
	        	 $('#sidr-id-checkAppStatusMenu').addClass('highlight');
		         $('#servicesMenu').addClass('active');
		         $('#sidr-id-servicesMenu').addClass('sidr-class-active');
		         return false;
	        }
	        if(current == 'termsandconditions' || current == 'profileinfo' ||current == 'contactinfo' || current == 'confirm'){
	        	 $('#retrieveSingPassMenu').addClass('active');
	        	 $('#sidr-id-retrieveSingPassMenu').addClass('highlight');
		         $('#servicesMenu').addClass('active');
		         $('#sidr-id-servicesMenu').addClass('sidr-class-active');
		         return false;
	        }
	        if(current == 'requestOnlineResetTermsCheck' || current == 'requestOnlineResetSecQuestCheck' || current == 'requestOnlineResetPersonDtCheck' 
	        			|| current == 'requestOnlineResetOtpCheck' || current == 'requestOnlineResetPasswordCheck' ||current == 'requestOnlineResetReqNewOtp' 
	        				|| current == 'otpToAltPrefmode' || current == 'mailMyPasswordTermsCheck' || current == 'mailMyPasswordPersonDtCheck'){
	        	 $('#resetPasswordMenu').addClass('active');
	        	 $('#sidr-id-resetPasswordMenu').addClass('highlight');
		         $('#servicesMenu').addClass('active');
		         $('#sidr-id-servicesMenu').addClass('sidr-class-active');
		         return false;
	        }
	        if(current == 'onlinePasswordChangepage' || current == 'onlinePasswordChangepageSubmit' || current == 'onlinePasswordChangeConfPage' 
	        			|| current == 'onlinePasswordChangeValidateOtp' || current == 'onlinePasswordChangeNewOtp'){
	        	 $('#changePasswordMenu').addClass('active');
	        	 $('#sidr-id-changePasswordMenu').addClass('highlight');
		         $('#myAccountMenu').addClass('active');
		         $('#sidr-id-myAccountMenu').addClass('sidr-class-active');
		         return false;
	        }
	        if(current == 'enquiretransaction' || current == 'displaytransaction'){
	        	 $('#accountHisMenu').addClass('active');
	        	 $('#sidr-id-accountHisMenu').addClass('highlight');
		         $('#myAccountMenu').addClass('active');
		         $('#sidr-id-myAccountMenu').addClass('sidr-class-active');
		         return false;
	        }
	        
	        if(current == 'profile' || current == 'addsqaprofile' || current == 'removesqaprofile' || current == 'validateotpprofile' || current == 'confirmchange'
	        			|| current == 'updatesingpassid' || current == 'validateotp' || current == 'confirmupdate' || current == 'changesingpassid'){
	             $('#updateProfileMenu').addClass('active');
	             $('#sidr-id-updateProfileMenu').addClass('highlight');
		         $('#myAccountMenu').addClass('active');
		         $('#sidr-id-myAccountMenu').addClass('sidr-class-active');
		         return false;
	        };
	        if(current == 'submitLogin' || current == 'loginpage'){
		         $('#homeMenu').addClass('active');
		         $('#sidr-id-homeMenu').addClass('sidr-class-active');
		         return false;
	        }
	        if(path.indexOf('\/setup2fa\/') >0){
	        	 $('#setup2faMenu').addClass('active');
	        	 $('#sidr-id-setup2faMenu').addClass('highlight');
		         $('#myAccountMenu').addClass('active');
		         $('#sidr-id-myAccountMenu').addClass('sidr-class-active');
		         return false;
	        }
	        if(path.indexOf('\/manage2fa\/') >0){
	        	 $('#manage2faMenu').addClass('active');
	        	 $('#sidr-id-manage2faMenu').addClass('highlight');
		         $('#myAccountMenu').addClass('active');
		         $('#sidr-id-myAccountMenu').addClass('sidr-class-active');
		         return false;
	        }
	    });
	 
		$( '.search' ).on( 'keydown', function ( evt ) {
		    if( evt.keyCode == 13 ){
		    	return searchQuery( $( this ));
		    }
		} ); 
		
		$( "#searchBtn" ).click(function() {
			//uat 293
			searchButtonClicked = true;
			searchQuery( $( '#searchBox' )); 
			});
		
		$( "#search" ).submit(function( event ) {
			  event.preventDefault();
			});
		
		$( "#mobileSearchBtn" ).click(function() {
			//uat 293
			searchButtonClicked = true;
			searchQuery( $( '#mobileSearchBox' )); 
			});
		
		$( "#mobileSearch" ).submit(function( event ) {
			  event.preventDefault();
			});
		
		$('.print').click(function() {
			  window.print();
			  return false;
			 });
		
		$('button').removeAttr('disabled');
	    $('form').submit(function(){
		    $('button').attr('disabled','disabled');
	    });
		
		// Ruly: Fix on the menu
		// Bind the function to show the sub-menu on Click and Mouse Enter
		$(".main-header .nav > ul > li").bind("click mouseenter", function() {
			if ($(this).parent() != null) {
				// Remove menuSelected class from all the Menu
				$(this).parent().children().removeClass("menuSelected");
			}
			
			// Add the menuSelected class to the current menu only
			if ( !$(this).hasClass("menuSelected") && !$(this).hasClass("active") ) {
				$(this).addClass("menuSelected");
			}
		});

	    // Stop user to press enter in textbox
        $("input").keypress(function(event) {
            if (event.keyCode == 13) {
                event.preventDefault();
                return false;
            }
        });
        
      //implement loading page
        $('#loadingDiv').hide();
	    $('form').submit(function(){
	    	//uat 293
	    	if(searchButtonClicked == false) {
	    		$('#loadingDiv').show();
	    		//uat 221
		    	$('#loadingDiv').css({
		    		'background-image': 'url(../resources/assets/img/SingPass-Logo-Loading-v02.1.gif)',
		    		'background-repeat': 'no-repeat',
		    		'background-position': 'center'
		    	});
	    	}
	    	else {
	    		//search button is clicked
	    		$('button').removeAttr('disabled');
	    		//reset search button value
	    		searchButtonClicked = false;
	    	}
	    });
});

function closeAnnouncement() {
	$.ajax({
	        type: "GET",
	        url: "/singpass/login/removeann", //controller method url
	        success: function(data){
			}
		});
 }

function searchQuery(ele) {
	$('button').removeAttr('disabled');
	//if ($.trim(ele.val()).length < 2)
    //	return ele.focus();
    var cx = '010781285529906403814:4ihl4o__8og';
    url = 'http://www.google.com/cse?cx=' + cx + '&q=' + ele.val();
    window.open(url);
    return false;
}
