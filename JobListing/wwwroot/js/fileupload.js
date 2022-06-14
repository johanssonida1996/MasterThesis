$(document).on('change','.up', function(){
    var names = [];
    var length = $(this).get(0).files.length;
      for (var i = 0; i < $(this).get(0).files.length; ++i) {
          names.push($(this).get(0).files[i].name);
      }
      // $("input[name=file]").val(names);
    if(length>2){
      var fileName = names.join(', ');
      $(this).closest('.form-group-files').find('.single-input').attr("value",length+" files selected");
    }
    else{
      $(this).closest('.form-group-files').find('.single-input').attr("value",names);
    }
 });