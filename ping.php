
<?php

	if(!isset($_POST["adress"])){ 
		$answer= new stdClass();
		$answer->ErrorCode='1';
		$answer->ErrorMessege="The parameter is not provide!";
		$resp=json_encode($answer);
		echo $resp;
		
	   
	}
	 else{
		 //$adress="www.google.com";
		 // $answer=new stdClass();
		 // preg_match_all('/Received = (?P<received>\d)/', $output, $matches4,PREG_OFFSET_CAPTURE);
		 $adress = $_POST["adress"]; 
		 $output=shell_exec("ping -n 3 $adress");
		 
		$data= preg_split("/[\s]+/", $output);
			if(strcmp($data[3],"not")!=0){
				
		
			
			
		
			 preg_match_all('/\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}/', $output, $matches,PREG_OFFSET_CAPTURE);
			 //echo $output;
			
			preg_match_all('/Sent = (?P<sent>\d)/', $output, $matches2,PREG_OFFSET_CAPTURE);
			preg_match_all('/Received = (?P<received>\d)/', $output, $matches3,PREG_OFFSET_CAPTURE);
			preg_match_all('/Lost = (?P<lost>\d)/', $output, $matches4,PREG_OFFSET_CAPTURE);
			preg_match_all('/Minimum = (?P<minimum>\d{1,3})ms/', $output, $matches5,PREG_OFFSET_CAPTURE);
			preg_match_all('/Maximum = (?P<maximum>\d{1,3})ms/', $output, $matches6,PREG_OFFSET_CAPTURE);
			preg_match_all('/Average = (?P<average>\d{1,3})ms/', $output, $matches7,PREG_OFFSET_CAPTURE);
		
			//echo $matches[0][4][0].' ';
			//echo $matches2['sent'][0][0].' ';
			//echo $matches3['received'][0][0].' ';
			//echo $matches4['lost'][0][0].' ';
			//echo $matches5['minimum'][0][0].' ';
			//echo $matches6['maximum'][0][0].' ';
			
			//echo $matches7['average'][0][0].' ';
		
			
			$result = array();
			$procesData = new stdClass();
				$procesData->Ip = $matches[0][4][0];
				$procesData->Sent = $matches2['sent'][0][0];
				$procesData->Received = $matches3['received'][0][0];
				$procesData->Lost = $matches4['lost'][0][0];
				$procesData->Minimum = $matches5['minimum'][0][0];
				$procesData->Maximum = $matches6['maximum'][0][0];
				$procesData->Average = $matches7['average'][0][0];
			
				$result = $procesData;
			
			$answer = new stdClass();
			$answer->Pings = $result;
			 $resp=json_encode($answer);
			 echo $resp;
		}
		else{
			
			$procesData = new stdClass();
				$procesData->Ip = "0";
				$procesData->Sent = "0";
				$procesData->Received = "0";
				$procesData->Lost = "0";
				$procesData->Minimum = "0";
				$procesData->Maximum = "0";
				$procesData->Average = "0";
			
				$result = $procesData;
			
			$answer = new stdClass();
			$answer->Pings = $result;
			 $resp=json_encode($answer);
			 echo $resp;
		}
	 }

?>