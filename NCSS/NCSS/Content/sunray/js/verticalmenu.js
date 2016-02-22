<!--//---------------------------------+
//  Developed by Roshan Bhattarai 
//  Visit http://roshanbh.com.np for this script and more.
//  This notice MUST stay intact for legal use
// --------------------------------->
$(document).ready(function()
{

		
	//slides the element with class "menu_body" when mouse is over the paragraph
	$("#firstpane p.menu_head_down").click(function()
    {    
if($(this).css('backgroundImage').indexOf('mminus_over.png') >0) 
{

$(this).css({backgroundImage:"url(../images/mplus.png)"}).next("div.menu_body").slideToggle(300).siblings("div.menu_body").slideUp("slow");
} 
else
{

$(this).css({backgroundImage:"url(../images/mminus_over.png)"}).next("div.menu_body").slideToggle(300).siblings("div.menu_body").slideUp("slow");
}


		 $(this).siblings().css({backgroundImage:"url(../images/mplus.png)"});
		 $("#firstpane p.menu_head").css({backgroundImage:"url(../images/mblank.png)"});
		
	});
	

    $('#firstpane p.menu_head').bind("mouseover", function(){             
	var color  = $(this).css("background-color");              
	$(this).css("background", "#33c");              
	$(this).bind("mouseout", function(){                 
	$(this).css("background", color);             
	})             
	})     
	

	
});

