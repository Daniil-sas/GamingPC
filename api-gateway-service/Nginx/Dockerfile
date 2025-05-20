FROM nginx:alpine

RUN rm /etc/nginx/conf.d/default.conf

COPY etc/nginx/ssl /etc/nginx/ssl

COPY nginx.conf /etc/nginx/conf.d/

RUN chmod 600 /etc/nginx/ssl/privkey.pem && \
    chmod -R nginx:nginx /etc/nginx/ssl

EXPOSE 443

CMD ["nginx", "-g", "daemon off;"]

