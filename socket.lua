print(wifi.sta.getip())
--nil
wifi.setmode(wifi.STATION)
wifi.sta.config("changwei","")
print(wifi.sta.getip())
--192.168.2.112

function setpin(in1,in2,in3,in4)
    gpio.write(pin1, in1)
    gpio.write(pin2, in2)
    gpio.write(pin3, in3)
    gpio.write(pin4, in4)
end

pin1 = 1
pin2 = 2
pin3 = 3
pin4 = 4
gpio.mode(pin1, gpio.OUTPUT)
gpio.mode(pin2, gpio.OUTPUT)
gpio.mode(pin3, gpio.OUTPUT)
gpio.mode(pin4, gpio.OUTPUT)

-- str = "<h1> ESP8266 Web Server For Car.</h1><h2>Code by cw1997</h2><hr>";
-- str = str..[[<script> function send(data){var xmlhttp=new XMLHttpRequest();xmlhttp.onreadystatechange=function(){console.info("success",data);document.getElementById("log").value=document.getElementById("log").value+"\nsuccess:"+data};xmlhttp.open("GET","?action="+data,true);xmlhttp.send()}; </script> &nbsp;&nbsp;&nbsp;<button onclick="send('front')">front</button><br> <button onclick="send('left')">left</button> <button onclick="send('right')">right</button><br> &nbsp;&nbsp;&nbsp;<button onclick="send('back')">back</button><hr> <button onclick="send('break')">break</button> <button onclick="send('stop')">stop</button><hr> <textarea id="log"></textarea>]]

srv=net.createServer(net.TCP)
srv:listen(80,function(conn)
    conn:on("receive", function(client,request)
        print(method, path, vars)
        if(request == "front")then
            setpin(0,1,1,0)
        elseif(request == "back")then
            setpin(1,0,0,1)
        elseif(request == "left")then
            setpin(0,0,1,0)
        elseif(request == "right")then
            setpin(0,1,0,0)
        elseif(request == "break")then
            setpin(1,1,1,1)
        elseif(request == "stop")then
            setpin(0,0,0,0)
        -- else
        --     client:send(str)
        --     print(#str)
        end
        client:send(request..' ok')
        -- client:close();
        -- collectgarbage();
    end)
end)
