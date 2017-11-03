jQuery.extend({
	createElementPA(sub,element){
		var musicID = new Array(
			'4872766',//心中的遗憾
			'4938705',//Dear friend 
			'421934070',//夏野与暗恋
			'541131',//时代を超える想い
			'540527'//Melodies of Life 
			);
		var i = 0;
		if (GsetInterval != null)
		{
			clearInterval(GsetInterval);
			$('.move').remove();
			console.log("清除定时器");
		}
		function createp()
		{
			var v = $('<p></p>');
			v.text(musicID[i]);
			if (i %2 ==0){
				v.addClass('subtitle-line-b');
			}
			else{
				v.addClass('subtitle-line-a');
			}
			v.addClass('white');
			v.addClass('move');
			if ((i++) >= musicID.length)
			{
				i=0;
			}
			element.append(v);
			return v;
		}
		createp();
		GsetInterval = setInterval(function(){
			var v = createp();
			setTimeout(function(){
				v.remove();
			},15000);
		},3000);
	}