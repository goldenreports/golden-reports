FROM node:18-alpine AS build
WORKDIR /dist/src/app
RUN npm cache clean --force
COPY ["package.json", "package-lock.json", "./"]
RUN npm ci --force
COPY . .
RUN npm run build golden-reports-manager --prod

FROM nginx:latest AS ngi
COPY --from=build /dist/src/app/dist /usr/share/nginx/html
COPY /nginx.conf  /etc/nginx/conf.d/default.conf
EXPOSE 80