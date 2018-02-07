<?php
if(!isset($_POST["value"]) ){ 
		$answer= new stdClass();
		$answer->ErrorCode='1';
		$answer->ErrorMessege="The parameter is not provide!";
		$resp=json_encode($answer);
		echo $resp;
	}
	$value=$_POST["value"];
	//$value="1";
 exec("nircmd.exe mutesysvolume $value");
?>