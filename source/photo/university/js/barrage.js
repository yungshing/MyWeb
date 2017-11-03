
var GsetInterval = null;//全局定时器

var moveTime = 13000;///弹幕移动时间 毫秒


jQuery.fn.extend({
	barrageAddMoveRL:function(){
		$(this).animate({
			left:'-10%'
		},moveTime,function(){
			$(this).remove();
		});
	}
});

jQuery.extend({

	///创建元素P
	createp(){
		var v = $('<p></p>');
		v.addClass('barrage');
		return v;
	},

	///text:<p>中的内容
	///hasBorder: bool 是否有边框
	createstyle(text,hasBorder){
		var v = $.createp();
		v.text(text);
		if (hasBorder){
			v.addClass('barrage-border');
		}
		return v;
	},
	///白色字体
	///无边框
	///左向右移
	styleA(text,element){
		var v = $.createstyle(text,false);
		element.append(v);
		v.addClass('barrage-font-white');
		v.addClass('barrage-position-a');
		v.barrageAddMoveRL();
		return v;
	},
	///蓝色字体
	///有边框
	///左向右移
	styleB(text,element){
		var v = $.createstyle(text,true);
		element.append(v);
		v.addClass('barrage-font-blue');
		v.addClass('barrage-position-a');
		v.barrageAddMoveRL();
		return v;
	}
});

