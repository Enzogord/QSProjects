## Поднимаем собственный сервис маршрутизации проще всего через Docker
1. Создаем каталог с данными можно в папке пользователя.
    mkdir osrm
    cd osrm/
2. Скачиваем файл региона с http://gis-lab.info
    wget -N http://data.gis-lab.info/osm_dump/dump/latest/RU-LEN.osm.pbf
3. Убедимся что докер установлен и запущен.
    sudo systemctl status docker.service
 1. Если не установлен устанавливаем
    sudo zypper in docker
 2. Запускаем
    sudo systemctl start docker.service
4. Скачиваем образ машины маршрутизации
    sudo docker pull osrm/osrm-backend
5. Подготавиливаем данные в папке
    sudo docker run -t -v $(pwd):/osrm osrm/osrm-backend osrm-extract -p /opt/car.lua /osrm/RU-LEN.osm.pbf
    sudo docker run -t -v $(pwd):/osrm osrm/osrm-backend osrm-contract /osrm/RU-LEN.osrm
6. Запускаем сервис
    sudo docker run -t -i -p 5000:5000 -v $(pwd):/osrm osrm/osrm-backend osrm-routed /osrm/RU-LEN.osrm
