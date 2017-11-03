jQuery(document).ready(function($) {
	$('#tP').text('123564');
	$('#tB').click(function(event) {
		/* Act on the event */
		$.ajax({
				type:"get",
				url:"/Post/GetVipCode.ashx",
				dataType:"jsonp",
				jsonp: "callback",
				data:{"gameID":"六点准时下班","game":1,"vip":1},
				success:function(data){
					$('#tP').text(data);
				},
				error:function()
				{
					alert("fail");
				}
			});
	});
});