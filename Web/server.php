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
    
    <div id = "link_wapper">
      <div style="width: 50%; float: left; border-right: 4px dotted #6c76be;">
      <h2><span>Độ C: <?php echo $doc; ?>°C</span></h2>
    </div>
      <h2><span>Độ F: <?php echo $dof; ?>°F</span></h2>
    <textarea name="Text1" cols="40" rows="20"><?php echo $readtime; ?></textarea> 
    </div>
