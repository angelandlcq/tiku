<script language="javascript"> 

  function KeyPress(objTR)  

 {
 //只允许录入数据字符 0-9 和小数点     //var objTR = element.document.activeElement;    

   var txtval=objTR.value;            

 var key = event.keyCode;     

 if((key < 48||key > 57)&&key != 46)     

 {         event.keyCode = 0;      }      

else     {       if(key == 46)      

 {        if(txtval.indexOf(".") != -1||txtval.length == 0)    

     event.keyCode = 0;      

 }     

 } 

  }   </script>
