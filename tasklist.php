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
			
		 $comanda="tasklist /FI ".'"ImageName eq '.$nume. '" /v /fo  table /nh ';
		 $output=shell_exec($comanda);
		 $data= preg_split("/[\s]+/", $output);
		 $result = array();
		
		for($i=0;$i<(sizeof($data)-2)/18;$i++)
		{
			$procesData = new stdClass();
			$procesData->ImageName = $data[$i*10+1];
			$procesData->PID = $data[$i*10+2];
			$procesData->SessionName = $data[$i*10+3];
			$procesData->SessionNumber = $data[$i*10+4];
			$procesData->MemUsage = $data[$i*10+5];
			$procesData->Status = $data[$i*10+7];
			$procesData->UserName = $data[$i*10+8];
			$procesData->CPUtime = $data[$i*10+9];
			$result[$i] = $procesData;
		}		
		$answer = new stdClass();
		$answer->Parameters = $result;
		 $resp=json_encode($answer);
		 echo $resp;
	}
?>