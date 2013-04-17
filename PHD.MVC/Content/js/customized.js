	$(document).ready(function(){  
	
		$( "#morder" ).mouseover(function(){$( "#morder" ).effect("bounce",{times:1,direction:"right",distance:5}, 600 ); });
 		$( "#mtrack" ).mouseover(function(){$( "#mtrack" ).effect("bounce",{times:1,direction:"right",distance:5}, 600 ); });
		$( "#mmobile" ).mouseover(function(){$( "#mmobile" ).effect("bounce",{times:1,direction:"right",distance:5}, 600 ); });
		$( "#mhangout" ).mouseover(function(){$( "#mhangout" ).effect("bounce",{times:1,direction:"right",distance:5}, 600 ); });	
		$( "#mcheck" ).mouseover(function(){$( "#mcheck" ).effect("bounce",{times:1,direction:"right",distance:5}, 600 ); });	
			// menu effects
		$('.drop').mouseenter(function(){$(this).find('ul').css({opacity: 0.0, visibility: "visible"}).animate({opacity: 1.0});$(this).find('table').animate({'margin-top':'15'});}).mouseleave(function(){$(this).find('ul').css("visibility","hidden");$(this).find('table').css('margin-top','0px');})
		
		
	});		
	