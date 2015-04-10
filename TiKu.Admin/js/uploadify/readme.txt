外联样式和js
<script type="text/javascript" src="../UpfileTool/MyToolmin.js"></script>
<script type="text/javascript" src="../UpfileTool/jquery.uploadify.js"></script>
<link rel="stylesheet" href="../UpfileTool/uploadify.css" type="text/css" media="screen" />
正文部分要放的

mode1
<input type="file" name="fileInput" id="fileInput" />
<br />
  <a href="javascript:$('#fileInput').fileUploadStart();">Upload Files</a> | <a href="javascript:$('#fileInput').fileUploadClearQueue();">Clear Queue</a>
<script type="text/javascript">
$(document).ready(function() {
$('#fileInput').fileUpload ({
//'uploader'  : 'uploader.swf',
//'script'    : 'UploadHandler.ashx',
//'cancelImg' : 'cancel.png',
//'auto'      : true,
//'multi'     : true,
//'simUploadLimit' : 3,
//'folder'    : '/upload'
//以下参数均是可选
'uploader'  : 'uploader.swf',   //指定上传控件的主体文件，默认‘uploader.swf’
'script'    : 'UploadHandler.ashx',       //指定服务器端上传处理文件，默认‘upload.php’
'cancelImg' : 'cancel.png',   //指定取消上传的图片，默认‘cancel.png’
'auto'      : false,               //选定文件后是否自动上传，默认false
'folder'    : '/upload',         //要上传到的服务器路径，默认‘/’
'muti'     : true,               //是否允许同时上传多文件，默认false
'fileDesc' : 'rar文件或zip文件',  //出现在上传对话框中的文件类型描述
'fileExt'   : '*.rar;*.zip',      //控制可上传文件的扩展名，启用本项时需同时声明fileDesc
'sizeLimit': 86400,          //控制上传文件的大小，单位byte
'simUploadLimit' :5         //多文件上传时，同时上传文件数目限制

});
});
</script>

mode2

<input type="file" name="fileInput" id="fileInput" />
<br />
  <a href="javascript:$('#fileInput').fileUploadStart();">Upload Files</a> | <a href="javascript:$('#fileInput').fileUploadClearQueue();">Clear Queue</a>
<script type="text/javascript">
$(document).ready(function() {
    $('#fileInput').fileUpload ({
         'uploader' : 'uploader.swf',
         'script' : 'UploadHandler.ashx',            //指定服务器端上传处理文件，默认‘upload.php’
         'cancelImg' : 'cancel.png',
         'folder' : '/upload',
         'buttonImg' : 'browse.png',
         'wmode' : 'transparent',
         'width' : 70,
         'queueID' : 'fileQueue',
         'fileDesc'  : '*.jpeg;*.png;*.gif;*.jpg',  //出现在上传对话框中的文件类型描述
         'fileExt'   : '*.jpeg;*.png;*.gif;*.jpg', //控制可上传文件的扩展名，启用本项时需同时声明fileDesc
         'auto' : false,                //选定文件后是否自动上传，默认false
         'multi' : true,               //是否允许同时上传多文件，默认false
         'sizeLimit' : 307200,          //控制上传文件的大小，单位byte   300K
         'simUploadLimit':3,            //多文件上传时，同时上传文件数目限制  
         'onComplete':function(event,queueID,file,response,data){
                   alert(response);
         }
      });
});
</script>
<div id="info"></div>