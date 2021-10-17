<?php

  $c = fopen('readc.txt', 'r');

  $f = fopen('readf.txt', 'r');

  $rt = fopen('readtime.txt', 'r');

  $doc = fread($c, filesize('readc.txt'));//đọc file
  $dof = fread($f, filesize('readf.txt'));//đọc file

  $readtime = fread($rt, filesize('readtime.txt'));//đọc file

  fclose($f);//đóng file
  fclose($c);//đóng file

?>
<!DOCTYPE html>
<html>
<title>Lập trình Arduino</title>
<meta charset="UTF-8">
<meta name="viewport" content="width=device-width, initial-scale=1">
<link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
<link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Raleway">
<style>
        body,h1 {font-family: "Roboto", sans-serif}
        body, html {height: 100%}
        .bgimg {
        background: url('thumb-1920-101504.jpg'), #6DB3F2;
        min-height: 100%;
        background-position: center;
        background-size: cover;
        }
        span{
            color:#00b8ff;
        }
        #link_wapper{
          background: #02111687;
          border: 1px solid #11ce5d;
          
          text-align: center;
        }
        textarea
        {
          float: right;
          width: 140px;
          text-align: center;
          background: #ffffffc9;
        }
        .info{
          background: #052c547a;
          padding: 10px 0px 10px 10px;
          width: 320px;
          height: 446px;
        }
}
</style>
<body>
  <div class="bgimg w3-display-container w3-animate-opacity w3-text-white">
    <div class="w3-display-topleft w3-padding-large w3-xlarge">
      Lập trình nhúng cơ bản
    </div>
    <div class="w3-display-middle">
      <h1 class="w3-jumbo w3-animate-top">Nhiệt độ hiện tại</h1> 

    
    <div id = "link_wapper">
      <div style="width: 50%; float: left; border-right: 4px dotted #6c76be;">
      <h2><span>Độ C: <?php echo $doc; ?>°C</span></h2>
</div>
      <h2><span>Độ F: <?php echo $dof; ?>°F</span></h2>
    <textarea name="Text1" cols="40" rows="20"><?php echo $readtime; ?></textarea> 
    </div>
    
  <div class ="info">
  <p class="w3-large w3-center w3-xlarge">Lớp CNTT K18</p>
  <p class="w3-large w3-center w3-xlarge">Nhóm 3</p>
    <p class="w3-large w3-center w3-xlarge">Giảng viên hướng dẫn: Đoàn Vũ Thịnh</p>
    <a target="blank" href="https://github.com/thinhdoanvu"><img src="giphy.gif" style="
    width: 50px; display: block; margin-left: auto; margin-right: auto;"></a>
    <p class="w3-large w3-center w3-xlarge"><a href="https://www.ttn.edu.vn/" target="_blank">Đại học Tây Nguyên</a></p>
    </div>
</div>

  </div>
</body>
</html>
<script>
function loadXMLDoc() {
  var xhttp = new XMLHttpRequest();
  xhttp.onreadystatechange = function() {
    if (this.readyState == 4 && this.status == 200) {
      document.getElementById("link_wapper").innerHTML =
      this.responseText;
    }
  };
  xhttp.open("GET", "server.php", true);
  xhttp.send();
}
setInterval(function () {
   loadXMLDoc();
   // 1 sec
},1000);
window.onload = loadXMLDoc;
</script>


