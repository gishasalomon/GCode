<?php

$serverName = "LAPTOP-3SCEJ975\SQLEXPRESS";
$connectionInfo = array( "Database"=>"TestCI","UID"=>"one" ,"PWD"=>"test1");
//$conn = new PDO( "sqlsrv:server=$serverName ; Database=TestCI", "one", "test1");
	
$conn = sqlsrv_connect( $serverName,$connectionInfo);
var_dump($conn);
			
if($conn)
	{
		$variables = array('Name', 'Designation', 'Country');
			
		foreach($variables as $variable_name)
		{

		if (isset($_POST[$variable_name])){
			echo 'Variable: '.$variable_name.' is set<br/>';
		}else{
			echo 'Variable: '.$variable_name.' is NOT set<br/>';
		}

		}
		if (isset($_POST['Name'])&& isset($_POST['Designation'])&& isset($_POST['Country']))
		{
			echo 'Connection OK and post variables are set';
			$mName=$_POST['Name'];
			$mDesignation=$_POST['Designation'];
			$mCountry=$_POST['Country'];
			$query ='Insert into people(Name, Designation,Country) values (?,?,?)';
			$parameters= array($mName,$mDesignation, $mCountry);
			$stmt= sqlsrv_query($conn, $query, $parameters);
			
		}
		else{
			echo 'Connection OK. Direct values are inserted to db';
			$query ='Insert into people(Name, Designation,Country) values (?,?,?)';
			$parameters= array("","", "");
			$stmt= sqlsrv_query($conn, $query, $parameters);
		}
	} else {echo 'No Connection';}

?>