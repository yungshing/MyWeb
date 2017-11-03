jQuery(function($) {
	$(document).ready(function(){
		var musicID = new Array(
			'4872766',//心中的遗憾
			'4938705',//Dear friend 
			'421934070',//夏野与暗恋
			'541131',//时代を超える想い
			'540527'//Melodies of Life 
			);
		var rid = $.Random(0,musicID.length);
		var link = "//music.163.com/outchain/player?type=2&id=mid&auto=1&height=66";
		$('#imusic').attr('src',link.replace('mid',musicID[rid]));
	
	});
});

jQuery.extend({
	Random:function(m,n)
	{
		return Math.floor(Math.random()*n+m);
	}
});
