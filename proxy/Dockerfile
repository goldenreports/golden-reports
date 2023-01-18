FROM alpine:latest as ssl
RUN apk add openssl
RUN openssl req -x509 -nodes -days 365 -subj "/C=CA/ST=QC/O=Company, Inc./CN=localhost" -addext "subjectAltName=DNS:localhost" -newkey rsa:2048 -keyout /nginx-selfsigned.key -out /nginx-selfsigned.crt

FROM nginx:alpine

COPY --from=ssl /nginx-selfsigned.key /etc/ssl/private/nginx-selfsigned.key
COPY --from=ssl /nginx-selfsigned.crt /etc/ssl/certs/nginx-selfsigned.crt

COPY /nginx.conf  /etc/nginx/conf.d/default.conf

EXPOSE 80/tcp
EXPOSE 443/tcp

WORKDIR /usr/share/nginx/html
CMD ["/bin/sh", "-c", "exec nginx -g 'daemon off;';"]
