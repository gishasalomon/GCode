<?php
require_once(dirname(_File_).'/ConnectionInfo.php');

if isset($_POST['Name'])&& isset($_POST['Designation'])&& isset($POST['Country']))
$mName=$_POST['Name'];
$mDesignation=$_POST['Designation'];
$mCountry=$_POST['Country'];

$connectioninfo=new ConnectionInfo();
$connectioninfo->GetConnection();

if (!$connectioninfo->conn)
{
	echo 'No Connection';
}

else
{
	$query ='Insert into people(Name, Designation,Country) values (?,?,?)' ;
	$parameters= array($mName,$mDesignation, $mCountry);
	
	$stmt= sqlsrv_query($connectioninfo->conn, $query, $parameters);
	
	
}

?>