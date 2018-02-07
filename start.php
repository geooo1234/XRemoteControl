
<?php

	if(!isset($_POST["nume"]) ){ 
		$answer= new stdClass();
		$answer->ErrorCode='1';
		$answer->ErrorMessege="The parameter is not provide!";
		$resp=json_encode($answer);
		echo $resp;
	}
	 else{
		$nume = $_POST["nume"];		 
		// exec("ping -n $numar $adress", $output, $status);
		//$nume="calc";
		 $comanda="start ".$nume ;
		 $output=shell_exec($comanda);
		 //$answer=new stdClass();
		// $answer->ErrorCode='0';
		 //$answer->Result=$output;
		// $resp=json_encode($answer);
		 //echo $resp;
	 }
?>