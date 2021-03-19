FROM node:alpine AS build
WORKDIR /app
COPY ./src/app/package.json ./
COPY ./src/app/package-lock.json ./
RUN npm ci
COPY ./src/app/* ./
RUN npx snowpack build
FROM nginx:alpine
COPY --from=build /app/build /var/www
CMD ["nginx -g 'daemon off;'"]