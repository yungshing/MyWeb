
$(document).ready(function() {

	///隐藏主菜单
	$('.level').hide();
	$.setVideoLink(-1);
		//隐藏大图，显示第一张小图
	$('.show-img-root').children().hide();
	$('.show-img-root').children().first().show();

    $('.show-video-root').children().hide();
    $('.show-video-root').children().first().show();


    $('.menu-panel').children().hide();


	$('.menu-root').mouseenter(function(event) {
		/* Act on the event */
		$('.level').stop(true);
		$('.level').slideUp();
		$('.level').slideDown(400);
	});
	$('.menu-root').mouseleave(function(event) {
		/* Act on the event */
		$('.level').stop(true);
		$('.level').slideDown();
		$('.level').slideUp(400);
	});
	$('.main_menu').mouseup(function(event) {
		/* Act on the event */
		if (event.which != 1)
		{
			return;
		}
		$('.menu-panel').children().hide();
		$.setVideoLink(-1);
		$('.welcome').hide();
		$('.welcome').show(400);
	});

	$('.menu-gallery').mouseup(function(event)
	{
		if (event.which != 1)
		{
			return;
		}
		$('.menu-panel').children().hide();
		$.setVideoLink(-1);
		$('.gallery-panel').show(200);
	});

	$('.menu-heiheihei').mouseup(function(event){
		if (event.which != 1)
		{
			return;
		}
		$('.menu-panel').children().hide();
		$('.video-panel').show(200);
		$.setVideoLink(0);
	});

	$('.show-img-list').mouseup(function(event) {
		if (event.which != 1)
		{
			return;
		}
		var currIndex = $('.show-img-list').index(this);
		$('.show-img-root').children().hide();
		$('.show-img-root').children().eq(currIndex).show(400);
		$.styleA("123456",$('.show-img-root').children().eq(currIndex));
	});
	$('.show-video-list').mouseup(function(event) {
		/* Act on the event */
		if (event.which != 1)
		{
			return;
		}
		var currIndex = $('.show-video-list').index(this);
		$.setVideoLink(currIndex);
	});
});

jQuery.extend({
	setVideoLink:function(_index){
		if (_index==-1)
		{
			$('#play-video-frame').attr('src','link');
		}
		else
		{
			var f = $('.video-link').eq(_index).attr('href');
			$('#play-video-frame').attr('src',f);
		}
	}
});