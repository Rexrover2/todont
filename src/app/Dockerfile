FROM node:alpine AS build
WORKDIR /app
COPY ./src/app/package.json ./package.json
COPY ./src/app/package-lock.json ./package-lock.json
RUN npm ci
COPY ./src/app/* ./
RUN ls -la ./
RUN npx snowpack build
FROM nginx:alpine
COPY --from=build /app/build /usr/share/nginx/html
CMD ["nginx -g 'daemon off;'"]
