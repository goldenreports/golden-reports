FROM node:18-alpine AS build
WORKDIR /src/app
RUN npm cache clean --force
COPY ["package.json", "package-lock.json", "./"]
RUN npm ci --force
COPY . .
RUN npm run build golden-reports-manager --prod

FROM node:slim
EXPOSE 4000/tcp

COPY --from=build /src/app/dist /

COPY ./entrypoint.sh /
RUN chmod +x entrypoint.sh

ENTRYPOINT ["sh","/entrypoint.sh"]
CMD ["node", "/golden-reports-manager/server/main.js"]
