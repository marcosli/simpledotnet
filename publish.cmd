@echo off
setlocal
set /p GC_USER="Username: "
set /p GC_PASS="Password: "
@echo on
call build Publish "/property:GCUsername=%GC_USER%" "/property:GCPassword=%GC_PASS%"
endlocal
