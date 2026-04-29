$incomeHost ="127.0.0.1"
$targethost="local.zooframework"
$pattern = '^'+ $incomeHost + '.*' + $targethost + '.*$'
$file = "$($env:SystemRoot)\System32\drivers\etc\hosts"
$hosts = Get-Content -Path $file
$matched = $FALSE
$hosts = $hosts | Foreach {
  if ($_ -match $pattern) 
  {
	$matched = $TRUE
  }
}
if(!$matched) {
  Add-Content $file "$incomeHost $targethost"
  echo "Hosts patched";
} else {
	echo "Hosts already patched"
}