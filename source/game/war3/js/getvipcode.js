jQuery(document).ready(function($) {
    $('#getcodebtn').click(function(event) {
    	/* Act on the event */
	    var gameID = $('#gameInfo input[id=gameID]').val();
	    console.log(gameID);
	    var vipLevel = $('#gameInfo select[name=vip]').val();
	    var gameName = $('#gameInfo select[name=game]').val();
    	$.ajax({
    		url: '/Post/GetVipCode.ashx',
    		//url:"http://localhost:52327/Post/GetVipCode.ashx",
    		type: 'get',
    		dataType:"jsonp",
    		jsonp: "callback",
    		data: {"gameID":gameID,"game":gameName,"vip":vipLevel},
    		success:function(data){
    			$('#vipCode').val(data);
    		},
    		error:function(){
    			$('#vipCode').val('未获取到数据');
    		}
    	});
    	
    });
});