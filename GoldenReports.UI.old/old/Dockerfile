FROM node:18-alpine AS build
WORKDIR /dist/src/app
RUN npm cache clean --force
COPY ["package.json", "package-lock.json", "./"]
RUN npm ci --force
COPY . .
RUN npm run build golden-reports-manager --prod

FROM nginx:alpine
EXPOSE 80/tcp

COPY /nginx.conf  /etc/nginx/conf.d/default.conf
RUN rm -rf /usr/share/nginx/html/*
COPY --from=build /dist/src/app/dist /usr/share/nginx/html
RUN nginx -t

COPY ./entrypoint.sh /
RUN chmod +x entrypoint.sh

ENTRYPOINT ["sh","/entrypoint.sh"]
CMD ["nginx", "-g", "daemon off;"]
